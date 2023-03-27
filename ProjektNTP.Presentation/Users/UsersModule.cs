using FluentValidation;
using FluentValidation.Results;
using ProjektNTP.Application.Services;
using ProjektNTP.Application.User.Dtos;

namespace ProjektNTP.Users;

public static class UsersModule
{
    public static void AddUsersEndpoints(this IEndpointRouteBuilder app)
    {
        
        app.MapPost("user", async (CreateUserDto user, IUserService service, IValidator<CreateUserDto> validator) =>
            {
                var validationResult = await validator.ValidateAsync(user);

                if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);
    
                var userCreated = await service.Create(user);
                return Results.Created("users/", userCreated);
            })
            .WithName("CreateUser")
            .Accepts<CreateUserDto>("application/json")
            .Produces<Guid>(201)
            .Produces<IEnumerable<ValidationFailure>>(400)
            .WithTags("Users");

        app.MapGet("users", async (IUserService service) =>
        {
            var result = await service.GetAllUsers();
            return Results.Ok(result);
        })
            .WithName("GetAllUsers")
            .Produces<List<GetUserDto>>(200)
            .Produces(404)
            .WithTags("Users");

        app.MapGet("users/{id:guid}", async (IUserService service, Guid id) =>
        {
            var result = await service.GetUserById(id);
            return result is not null ? Results.Ok(result) : Results.NotFound();
        })
            .WithName("GetUserById")
            .Produces<GetUserDto>(200)
            .Produces(404)
            .WithTags("Users");
    }
}