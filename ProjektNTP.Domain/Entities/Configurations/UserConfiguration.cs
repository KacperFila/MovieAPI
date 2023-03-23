using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjektNTP.Entities;

namespace ProjektNTP.Domain.Entities.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(u => u.UserContactDetails).WithOne(ucd => ucd.User).HasForeignKey<UserContactDetails>(ucd => ucd.UserId);
        builder.HasOne(u => u.Role).WithMany(r => r.Users);
        builder.HasMany(u => u.Showings).WithMany(s => s.Viewers)
            .UsingEntity<Reservation>(
                r => r.HasOne(x => x.Showing)
                    .WithMany()
                    .HasForeignKey(x => x.ShowingId),
                r => r.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId),
                r => r.HasKey(x => x.Id)
                );
    }
}