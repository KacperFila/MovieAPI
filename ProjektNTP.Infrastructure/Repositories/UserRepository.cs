using ProjektNTP.Abstractions;
using ProjektNTP.Entities;

namespace ProjektNTP.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
}

