using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProjektNTP;
using ProjektNTP.Application.Extensions;
using ProjektNTP.Application.Services;
using ProjektNTP.Application.User.Dtos;
using ProjektNTP.Infrastructure.Extensions;
using ProjektNTP.Infrastructure.Seeders;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DevelopConnectionString");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<AppDbContext>()!;
UserSeeder.Seed(dbContext);
MovieCinemaSeeder.Seed(dbContext);

app.UseSwagger();
app.UseSwaggerUI();




app.MapPost("user", async (CreateUserDto user, IUserService service, IValidator<CreateUserDto> validator) =>
{
    var validationResult = await validator.ValidateAsync(user);

    if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);
    
    var userCreated = await service.Create(user);
    return Results.Created("users/", userCreated);
});

app.MapGet("users", async (IUserService service) =>
{
    var result = await service.GetAllUsers();
    return Results.Ok(result);
});

app.Run();