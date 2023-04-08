using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProjektNTP.Application.Mappers;
using ProjektNTP.Application.Services;
using ProjektNTP.Application.User.Dtos;
using ProjektNTP.Application.User.Validators;
using ProjektNTP.Domain.Validators;

namespace ProjektNTP.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IShowingService, ShowingService>();

        services.AddValidatorsFromAssemblyContaining<UserValidator>();

        services.AddAutoMapper(typeof(UserMappingProfile));
    }
}