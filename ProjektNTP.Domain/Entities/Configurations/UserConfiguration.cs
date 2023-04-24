using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjektNTP.Domain.Entities.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(u => u.Role).WithMany();
        builder.HasMany(u => u.Reservations).WithOne(r => r.User);
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(30);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(30);
        builder.Property(u => u.PasswordHash).IsRequired();
    }
}