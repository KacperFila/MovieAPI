using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using ProjektNTP.Application.Extensions;
using ProjektNTP.Domain;
using ProjektNTP.Infrastructure.Extensions;
using ProjektNTP.Infrastructure.Seed;
using ProjektNTP.Infrastructure.Seeders;
using ProjektNTP.Movies;
using ProjektNTP.OptionsSetup;
using ProjektNTP.Showings;
using ProjektNTP.Users;


var builder = WebApplication.CreateBuilder(args);



var connectionString = builder.Configuration.GetConnectionString("DevelopConnectionString");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<AppDbContext>()!;
//UserSeeder.Seed(dbContext);
//MovieCinemaSeeder.Seed(dbContext);

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.AddUsersEndpoints();
app.AddMoviesEndpoints();
app.AddShowingsEndpoints();


app.Run();