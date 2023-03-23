using Microsoft.Extensions.DependencyInjection;
using ProjektNTP.Application.Services;

namespace ProjektNTP.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
}
