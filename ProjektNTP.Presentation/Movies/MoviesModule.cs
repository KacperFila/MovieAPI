using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using ProjektNTP.Application.Movie.Dtos;
using ProjektNTP.Application.Services;
using ProjektNTP.Domain.Entities;

namespace ProjektNTP.Movies;

public static class MoviesModule
{
    public static void AddMoviesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("movie", async (CreateMovieDto movie, IMovieService service, IValidator<CreateMovieDto> validator) =>
                {
                    var validationResult = await validator.ValidateAsync(movie);
                    if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

                    var addedMovie = await service.CreateMovie(movie);
                    return Results.Created("movies/", addedMovie);

                })
            .WithName("CreateMovie")
            .Accepts<CreateMovieDto>("application/json")
            .Produces<Guid>()
            .Produces<IEnumerable<ValidationFailure>>(400)
            .WithTags("Movies");
        
        
        app.MapGet("movies", async (IMovieService service) =>
        {
            var movies = await service.GetAllMovies();
            return movies is not null ?  Results.Ok(movies) : Results.NotFound();
        })
            .WithName("GetAllMovies")
            .Produces<List<GetMovieDto?>>()
            .Produces(404)
            .WithTags("Movies");
        
        app.MapGet("movie/{id:guid}", async (IMovieService service, Guid id) =>
        {
            var movie = await service.GetMovieById(id);
            return movie is not null ? Results.Ok(movie) : Results.NotFound();
        })
            .WithName("GetMovieById")
            .Produces<GetMovieDto?>()
            .Produces(404)
            .WithTags("Movies");

        app.MapPut("movie/{id:guid}", async (IMovieService service, Guid id, CreateMovieDto movie, IValidator<CreateMovieDto> validator) =>
            {
                var validationResult = await validator.ValidateAsync(movie);
                if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);
            var updatedMovie = await service.UpdateMovie(id, movie);
            return updatedMovie ?  Results.Ok(id) : Results.NotFound();
        })
            .WithName("UpdateMovie")
            .Produces<Guid>()
            .Produces<IEnumerable<ValidationFailure>>(404)
            .WithTags("Movies");
    }
}