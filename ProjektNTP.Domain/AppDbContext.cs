using Microsoft.EntityFrameworkCore;
using ProjektNTP.Domain.Entities;
using ProjektNTP.Entities;

namespace ProjektNTP;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions opt) : base(opt)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserContactDetails> UsersContactDetails { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Showing> Showings { get; set; }
}