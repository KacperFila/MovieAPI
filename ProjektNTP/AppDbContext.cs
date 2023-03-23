using Microsoft.EntityFrameworkCore;
using ProjektNTP.Entities;

namespace ProjektNTP;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions opt) : base(opt)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
}