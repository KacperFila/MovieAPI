using Bogus;
using ProjektNTP.Domain.Entities;
using ProjektNTP.Entities;

namespace ProjektNTP.Infrastructure.Seeders;

public static class MovieCinemaSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Movies.Any())
        {
            var movieGenerator = new Faker<Movie>("pl")
                .RuleFor(m => m.Name, f => f.Lorem.Word())
                .RuleFor(m => m.Duration, f => f.Random.Int(60, 90))
                .RuleFor(m => m.ReleasedDate, f => f.Date.Past(5));

            var movies = movieGenerator.Generate(10);
            context.AddRange(movies);
            context.SaveChanges();
        }

        if (!context.Cinemas.Any())
        {
            var addressGenerator = new Faker<Address>("pl")
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Street, f => f.Address.StreetName())
                .RuleFor(a => a.BuildingNumber, f => f.Address.BuildingNumber())
                .RuleFor(a => a.PostalCode, f => f.Address.ZipCode());


            var cinemaGenerator = new Faker<Cinema>("pl")
                .RuleFor(c => c.Name, f => f.Lorem.Word())
                .RuleFor(c => c.Address, f => addressGenerator.Generate());

            var cinemas = cinemaGenerator.Generate(5);
            context.AddRange(cinemas);
            context.SaveChanges();
        }
    }
}