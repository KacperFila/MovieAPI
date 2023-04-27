using ProjektNTP.Application.User.Dtos;

namespace ProjektNTP.Application.Services;

public interface IJwtProvider
{
    string GenerateJwt(Domain.Entities.User user);
}