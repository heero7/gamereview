using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    private const string TableName = "Genres";
    
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Name)
            .IsRequired().HasColumnType("varchar(150)");
        
        // 1 : N => Genre : Games
        // 1 to many
        builder
            .HasMany(g => g.Games)
            .WithOne(gme => gme.Genre)
            .HasForeignKey(gme => gme.GenreId);

        builder.ToTable(TableName);
    }
}