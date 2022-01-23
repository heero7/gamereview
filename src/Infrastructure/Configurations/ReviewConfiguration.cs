using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    private const string TableName = "Reviews";
    
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Title).IsRequired()
            .HasColumnType("varchar(150)");

        builder.Property(r => r.Author).IsRequired().HasColumnType("varchar(200)");

        builder.Property(r => r.ReviewDescription).HasColumnType("varchar(500)");

        builder.Property(r => r.PostedDate).IsRequired();

        builder.Property(r => r.GameId).IsRequired();

        builder.ToTable(TableName);
    }

    
}