using Microsoft.EntityFrameworkCore;
using ProjektNTP;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DevelopConnectionString");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();
app.Run();