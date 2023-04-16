using Microsoft.EntityFrameworkCore;
using ProjektNTP;
using ProjektNTP.Application.Extensions;
using ProjektNTP.Domain;
using ProjektNTP.Infrastructure.Extensions;
using ProjektNTP.Infrastructure.Seed;
using ProjektNTP.Infrastructure.Seeders;
using ProjektNTP.Movies;
using ProjektNTP.Showings;
using ProjektNTP.Users;


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

app.AddUsersEndpoints();
app.AddMoviesEndpoints();
app.AddShowingsEndpoints();

app.Run();