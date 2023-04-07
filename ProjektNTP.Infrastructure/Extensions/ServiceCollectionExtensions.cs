using Microsoft.Extensions.DependencyInjection;
using ProjektNTP.Domain.Abstractions;
using ProjektNTP.Infrastructure.Repositories;

namespace ProjektNTP.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();
    }
}