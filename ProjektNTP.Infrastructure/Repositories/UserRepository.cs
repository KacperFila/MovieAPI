﻿using Microsoft.EntityFrameworkCore;
using ProjektNTP.Domain;
using ProjektNTP.Domain.Abstractions;
using ProjektNTP.Domain.Entities;

namespace ProjektNTP.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Guid?> Register(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return await Task.FromResult(user.Id);
    }
    
    public async Task<List<User>?> GetAllUsers()
    {
        var users = await _context.Users
            .Include(u => u.Role)
            .ToListAsync();
        return await Task.FromResult(users);
    }
    
    public async Task<User?> GetUserById(Guid id)
    {
        var user = await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Id == id);
        return await Task.FromResult(user);
    }
    
    public async Task<User?> GetUserByEmail(string email)
    {
        var user = await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == email);
        return await Task.FromResult(user);
    }
    
    public async Task<bool> DeleteUserById(Guid id)
    {
        var userToDelete = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
    
        if (userToDelete == null) return await Task.FromResult(false);
        _context.Remove(userToDelete);
        await _context.SaveChangesAsync();
        return await Task.FromResult(true);
    }
    
    public async Task<Guid?> UpdateUserById(Guid id, User user)
    {
        var userToUpdate = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
        if (userToUpdate is null) return await Task.FromResult<Guid?>(null);

        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;
        userToUpdate.RoleId = user.RoleId;
    
        await _context.SaveChangesAsync();
        return await Task.FromResult(id);
    }
}