using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjektNTP.Domain.Entities.Configurations;

public class ShowingConfiguration : IEntityTypeConfiguration<Showing>
{
    public void Configure(EntityTypeBuilder<Showing> builder)
    {
        builder.HasOne(s => s.Movie).WithMany(m => m.Showings);
        builder.HasOne(s => s.Cinema).WithMany(c => c.Showings);
        
    }
}