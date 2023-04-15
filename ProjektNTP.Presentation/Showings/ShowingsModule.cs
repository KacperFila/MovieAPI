using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using ProjektNTP.Application.Services;
using ProjektNTP.Application.Showing.Dtos;

namespace ProjektNTP.Showings;

public static class ShowingsModule
{
    public static void AddShowingsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("showings",
                async (IShowingService service, CreateShowingDto showing, IValidator<CreateShowingDto> validator) =>
                {
                    var validationResult = await validator.ValidateAsync(showing);
                    if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

                    var createdShowing = await service.CreateShowing(showing);
                    return Results.CreatedAtRoute("GetShowingById", new {id = createdShowing});
                })
            .WithName("CreateShowing")
            .Accepts<CreateShowingDto>("application/json")
            .Produces<Guid>(201)
            .Produces<IEnumerable<ValidationFailure>>(400)
            .WithTags("Showings");

        app.MapGet("showings", async (IShowingService service) =>
            {
                var showings = await service.GetAllShowings();
                return showings is not null ? Results.Ok(showings) : Results.NotFound();
            })
            .WithName("GetAllShowings")
            .Produces<List<GetShowingDto>>()
            .Produces(404)
            .WithTags("Showings");

        app.MapGet("showings/{id:guid}", async (IShowingService service, Guid id) =>
            {
                var showing = await service.GetShowingById(id);
                return showing is not null ? Results.Ok(showing) : Results.NotFound();
            })
            .WithName("GetShowingById")
            .Produces<GetShowingDto>()
            .Produces(404)
            .WithTags("Showings");

        app.MapPut("showings/{id:guid}", async (Guid id, IShowingService service, CreateShowingDto showing,
                IValidator<CreateShowingDto> validator) =>
            {
                var validationResult = await validator.ValidateAsync(showing);
                if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

                var isShowingUpdated = await service.UpdateShowingById(id, showing);
                return isShowingUpdated ? Results.CreatedAtRoute("GetShowingById", id) : Results.NotFound();

            })
            .WithName("UpdateShowingById")
            .Accepts<CreateShowingDto>("application/json")
            .Produces<Guid>(201)
            .Produces<IEnumerable<ValidationFailure>>(400)
            .WithTags("Showings");

        app.MapDelete("showings/{id:guid}", async (Guid id, IShowingService service) =>
            {
                var isShowingDeleted = await service.DeleteShowingById(id);
                return isShowingDeleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteShowingById")
            .Produces<bool>()
            .WithTags("Showings");
    }
}