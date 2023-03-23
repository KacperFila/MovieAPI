using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjektNTP.Entities.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(u => u.PhoneNumber).WithOne(pn => pn.User).HasForeignKey<PhoneNumber>(pn => pn.UserId);
        builder.HasOne(u => u.Role).WithMany(r => r.Users);
    }
}