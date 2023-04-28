using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace ProjektNTP.Application.Services;

public interface IUserContextService
{
    ClaimsPrincipal User { get; }
    Guid? UserId { get; }
}

public class UserContextService : IUserContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;
    public Guid? UserId => User is null ? null : Guid.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
}