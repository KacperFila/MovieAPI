using Bogus;
using ProjektNTP.Entities;

namespace ProjektNTP.Infrastructure.Seeders;

public static class UserSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Users.Any())
        {
            var roles = new List<Role>()
            {
                new()
                {
                    Name = "Administrator"
                },
                new()
                {
                    Name = "Użytkownik"
                },
            };


            var userContactDetailsGenerator = new Faker<UserContactDetails>("pl")
                .RuleFor(u => u.Email, f => f.Person.Email)
                .RuleFor(u => u.PhoneNumber, f => f.Person.Phone);

            var userGenerator = new Faker<User>("pl")
                .RuleFor(u => u.FirstName, f => f.Person.FirstName)
                .RuleFor(u => u.LastName, f => f.Person.LastName)
                .RuleFor(u => u.Role, f => f.PickRandom(roles))
                .RuleFor(u => u.UserContactDetails, f => userContactDetailsGenerator.Generate());

            var users = userGenerator.Generate(10);
            context.AddRange(users);
            context.SaveChanges();

        }
    }
}