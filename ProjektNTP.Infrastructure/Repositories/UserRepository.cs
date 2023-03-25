﻿using ProjektNTP.Application.User.Dtos;
using ProjektNTP.Domain.Abstractions;
using ProjektNTP.Entities;

namespace ProjektNTP.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Create(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }
}

