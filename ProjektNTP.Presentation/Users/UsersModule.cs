using FluentValidation;
using ProjektNTP.Application.Authorization.Policies;
using ProjektNTP.Application.Services;
using ProjektNTP.Application.User.Dtos;
using ValidationFailure = FluentValidation.Results.ValidationFailure;

namespace ProjektNTP.Users;

public static class UsersModule
{
    
    public static void AddUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("users", async (CreateUserDto user, IUserService service, IValidator<CreateUserDto> validator) =>
            {
                var validationResult = await validator.ValidateAsync(user);

                if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

                var userCreated = await service.Register(user);

                return userCreated is not null
                    ? Results.CreatedAtRoute("GetUserById", new { id = userCreated })
                    : Results.BadRequest($"User with email : {user.Email} already exists.");
                })
            .WithName("CreateUser")
            .Accepts<CreateUserDto>("application/json")
            .Produces<Guid>(201)
            .Produces<IEnumerable<ValidationFailure>>(400)
            .WithTags("Users");

        app.MapGet("users", async (IUserService service) =>
            {
                var result = await service.GetAllUsers();
                return result.Any() ? Results.Ok(result) : Results.NotFound();
            })
            .RequireAuthorization(builder => builder.RequireRole("Administrator"))
            .WithName("GetAllUsers")
            .Produces<List<GetUserDto>>()
            .Produces(404)
            .WithTags("Users");

        app.MapGet("users/{id:guid}", async (IUserService service, Guid id) =>
            {
                var result = await service.GetUserById(id);
                return result is not null ? Results.Ok(result) : Results.NotFound();
            })
            .RequireAuthorization()
            .WithName("GetUserById")
            .Produces<GetUserDto>()
            .Produces(404)
            .WithTags("Users");

        app.MapDelete("users/{id:guid}", async (IUserService service, Guid id) =>
            {
                var deletedResult = await service.DeleteUserById(id);
                return deletedResult ? Results.NoContent() : Results.BadRequest($"No user with id: {id} was found!");
            })
            .WithName("DeleteUserById")
            .Produces(204)
            .Produces(404)
            .WithTags("Users");

        app.MapPost("login", async (LogUserDto userDto, IAuthenticationService authenticationService, IJwtProvider provider) =>
        {
            var user = await authenticationService.VerifyUser(userDto);
            if (user == null)
            {
                return Results.Unauthorized();
            }

            var tokenResult = provider.GenerateJwt(user);
            return Results.Ok(tokenResult);
        });
        
        app.MapPut("users/{id:guid}",
                async (IUserService service, Guid id, UpdateUserDto user, IValidator<UpdateUserDto> validator) =>
                {
                    var validationResult = await validator.ValidateAsync(user);
                    if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);
        
                    user.Id = id;
                    var updatedResult = await service.UpdateUserById(id, user);
                    return updatedResult is not null ? Results.Ok() : Results.BadRequest($"No user with id: {id} was found!");
                })
            .RequireAuthorization()
            .WithName("UpdateUserById")
            .Accepts<UpdateUserDto>("application/json")
            .Produces(200)
            .Produces(404)
            .WithTags("Users");
    }
}