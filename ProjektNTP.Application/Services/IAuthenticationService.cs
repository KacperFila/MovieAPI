using ProjektNTP.Application.User.Dtos;

namespace ProjektNTP.Application.Services;

public interface IAuthenticationService
{
    public Task<Domain.Entities.User?> VerifyUser(LogUserDto logUserDto);
}