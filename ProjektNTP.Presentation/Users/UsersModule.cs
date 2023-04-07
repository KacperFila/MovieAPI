using FluentValidation;
using FluentValidation.Results;
using ProjektNTP.Application.Services;
using ProjektNTP.Application.User.Dtos;

namespace ProjektNTP.Users;

public static class UsersModule
{
    public static void AddUsersEndpoints(this IEndpointRouteBuilder app)
    {
        
        app.MapPost("users", async (CreateUserDto user, IUserService service, IValidator<CreateUserDto> validator) =>
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
            return result.Any() ? Results.Ok(result) : Results.NotFound();
        })
            .WithName("GetAllUsers")
            .Produces<List<GetUserDto>>()
            .Produces(404)
            .WithTags("Users");

        app.MapGet("users/{id:guid}", async (IUserService service, Guid id) =>
        {
            var result = await service.GetUserById(id);
            return result is not null ? Results.Ok(result) : Results.NotFound();
        })
            .WithName("GetUserById")
            .Produces<GetUserDto>()
            .Produces(404)
            .WithTags("Users");
        
        app.MapDelete("users/{id:guid}", async (IUserService service, Guid id ) =>
        {
            var deletedResult = await service.DeleteUserById(id);
            return deletedResult ? Results.NoContent() : Results.BadRequest($"No user with id: {id} was found!");
        })
            .WithName("DeleteUserById")
            .Produces(204)
            .Produces(404)
            .WithTags("Users");
        
        app.MapPut("users/{id:guid}", async (IUserService service, Guid id, CreateUserDto user, IValidator<CreateUserDto> validator) =>
        {
            var validationResult = await validator.ValidateAsync(user);
            if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

            user.Id = id;
            var updatedResult = await service.UpdateUserById(id, user);
            return updatedResult ? Results.Ok() : Results.BadRequest($"No user with id: {id} was found!");
        })
            .WithName("UpdateUserById")
            .Accepts<CreateUserDto>("application/json")
            .Produces(200)
            .Produces(404)
            .WithTags("Users");
    }
    
    
}