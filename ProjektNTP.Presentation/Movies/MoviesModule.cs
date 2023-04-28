using System.Security.Claims;
using FluentValidation;
using FluentValidation.Results;
using ProjektNTP.Application.Movie.Dtos;
using ProjektNTP.Application.Services;

namespace ProjektNTP.Movies;

public static class MoviesModule
{
    public static void AddMoviesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("movies",
                async (CreateMovieDto movie, IMovieService service, IValidator<CreateMovieDto> validator, HttpContext context) =>
                {
                    var userId = Guid.Parse(context.User.FindFirst(c => c.Type ==  ClaimTypes.NameIdentifier)!.Value);
                    var validationResult = await validator.ValidateAsync(movie);
                    if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

                    var addedMovie = await service.CreateMovie(movie, userId);
                    return Results.Created("movies/", addedMovie);
                })
            .RequireAuthorization()
            .WithName("CreateMovie")
            .Accepts<CreateMovieDto>("application/json")
            .Produces<Guid>()
            .Produces<IEnumerable<ValidationFailure>>(400)
            .WithTags("Movies");


        app.MapGet("movies", async (IMovieService service) =>
            {
                var movies = await service.GetAllMovies();
                return movies is not null ? Results.Ok(movies) : Results.NotFound();
            })
            .WithName("GetAllMovies")
            .Produces<List<GetMovieDto?>>()
            .Produces(404)
            .WithTags("Movies");

        app.MapGet("movies/{id:guid}", async (IMovieService service, Guid id) =>
            {
                var movie = await service.GetMovieById(id);
                return movie is not null ? Results.Ok(movie) : Results.NotFound();
            })
            .WithName("GetMovieById")
            .Produces<GetMovieDto?>()
            .Produces(404)
            .WithTags("Movies");

        app.MapPut("movies/{movieId:guid}",
                async (IMovieService service, Guid movieId, CreateMovieDto movieDto, IValidator<CreateMovieDto> validator) =>
                {
                        var validationResult = await validator.ValidateAsync(movieDto);
                        if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

                        var updatedMovie = await service.UpdateMovieById(movieId, movieDto);
                        return updatedMovie ? Results.Ok(movieId) : Results.NotFound();
                    
                })
            .WithName("UpdateMovieById")
            .Produces<Guid>()
            .Produces<IEnumerable<ValidationFailure>>(404)
            .WithTags("Movies");

        app.MapDelete("movies/{id:guid}", async (IMovieService service, Guid id) =>
            {
                try
                {
                    var deleteResult = await service.DeleteMovie(id);
                    return deleteResult ? Results.NoContent() : Results.NotFound();
                }
                catch (UnauthorizedAccessException)
                {
                    return Results.StatusCode(403);
                }
            })
            .WithName("DeleteMovieById")
            .Produces(204)
            .Produces(404)
            .WithTags("Movies");
    }
}