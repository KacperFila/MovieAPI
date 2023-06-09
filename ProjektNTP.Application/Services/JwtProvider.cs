﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ProjektNTP.Application.Services;

internal sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;

    public JwtProvider(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string GenerateJwt(Domain.Entities.User user)
    {
        var claims = new Claim[]
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Email, user.Email), 
            new (ClaimTypes.Role, user.Role.Name)
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.SecretKey))
            , SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(3),
            signingCredentials
        );

        string tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token).Replace("\"", "");

        return tokenValue;
    }
}