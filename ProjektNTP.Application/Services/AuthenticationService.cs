using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using ProjektNTP.Application.User.Dtos;
using ProjektNTP.Domain.Abstractions;

namespace ProjektNTP.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;
    private readonly IJwtProvider _provider;
    
    public AuthenticationService(IUserRepository userRepository, IPasswordHasher<Domain.Entities.User> passwordHasher, IJwtProvider provider)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _provider = provider;
    }

    public async Task<Domain.Entities.User?> AuthenticateAsync(LogUserDto logUserDto)
    {
        var user = await _userRepository.GetUserByEmail(logUserDto.Email);
        if (user is null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, logUserDto.Password) == PasswordVerificationResult.Failed)
        {
            return null;
        };
        return user;
    }
}