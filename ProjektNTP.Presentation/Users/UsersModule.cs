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
                return Results.CreatedAtRoute("GetUserById", new {id = userCreated});
            })
            .WithName("CreateUser")
            .Accepts<CreateUserDto>("application/json")
            .Produces<Guid>(201)
            .Produces<IEnumerable<ValidationFailure>>(400)
            .WithTags("Users");

        app.MapGet("users", async (IUserService service) =>
        {
            var users = await service.GetAllUsers();
            return users.Any() ? Results.Ok(users) : Results.NotFound();
        })
            .WithName("GetAllUsers")
            .Produces<List<GetUserDto>?>()
            .Produces(404)
            .WithTags("Users");

        app.MapGet("users/{id:guid}", async (IUserService service, Guid id) =>
        {
            var user = await service.GetUserById(id);
            return user is not null ? Results.Ok(user) : Results.NotFound($"User with id {id} has not been found.");
        })
            .WithName("GetUserById")
            .Produces<GetUserDto>()
            .Produces(404)
            .WithTags("Users");
        
        app.MapPut("users/{id:guid}", async (IUserService service, Guid id, CreateUserDto user, IValidator<CreateUserDto> validator) =>
            {
                var validationResult = await validator.ValidateAsync(user);
                if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);
            
                var updatedResult = await service.UpdateUserById(id, user);
                return updatedResult is not null
                    ? Results.Ok($"User with id: {updatedResult} has been updated successfully.")
                    : Results.BadRequest($"No user with id: {id} has been found!");
            })
            .WithName("UpdateUserById")
            .Accepts<CreateUserDto>("application/json")
            .Produces(200)
            .Produces(404)
            .Produces<IEnumerable<ValidationFailure>>(400)
            .WithTags("Users");
        
        app.MapDelete("users/{id:guid}", async (IUserService service, Guid id ) =>
        {
            var isUserDeleted = await service.DeleteUserById(id);
            return isUserDeleted ? Results.NoContent() : Results.BadRequest($"No user with id: {id} has been found.");
        })
            .WithName("DeleteUserById")
            .Produces(204)
            .Produces(404)
            .WithTags("Users");
        
        
    }
}