using Microsoft.EntityFrameworkCore;
using ProjektNTP;
using ProjektNTP.Abstractions;
using ProjektNTP.Application.Extensions;
using ProjektNTP.Application.Services;
using ProjektNTP.Entities;
using ProjektNTP.Infrastructure.Extensions;
using ProjektNTP.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DevelopConnectionString");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.Run();