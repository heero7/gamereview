using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    private const string TableName = "Games";
    
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Name).IsRequired().HasColumnType("varchar(150)");

        builder.Property(g => g.ReleasedDate).IsRequired().HasColumnType("date");

        builder.Property(g => g.GenreId).IsRequired();

        builder.ToTable(TableName);
    }
}