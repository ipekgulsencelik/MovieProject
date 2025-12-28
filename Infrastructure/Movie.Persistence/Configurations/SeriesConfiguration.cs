using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Persistence.Configurations
{
    public class SeriesConfiguration : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.ToTable("Series");

            builder.Property(x => x.DataStatus)
                   .HasConversion<int>();

            builder.Property(x => x.CreatedDate)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            builder.Property(x => x.IsVisible)
                   .HasDefaultValue(false);

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.CoverImageUrl)
                   .HasMaxLength(500);

            builder.Property(x => x.Description)
                   .HasMaxLength(2000);

            builder.Property(x => x.Rating)
                   .HasPrecision(3, 1)
                   .HasDefaultValue(0m);

            builder.Property(x => x.FirstAirDate)
                   .IsRequired();

            builder.Property(x => x.AverageEpisodeDuration);

            builder.Property(x => x.SeasonCount)
                   .HasDefaultValue(0);

            builder.Property(x => x.EpisodeCount)
                   .HasDefaultValue(0);

            builder.Property(x => x.SeriesStatus)
                   .HasConversion<int>()
                   .HasDefaultValue(SeriesStatus.Ongoing);

            builder.Property(x => x.PreviousStatus)
                   .HasConversion<int?>();

            // Index (opsiyonel ama iyi)
            builder.HasIndex(x => x.FirstAirDate);
            builder.HasIndex(x => x.SeriesStatus);

            builder.HasIndex(x => new
            {
                x.SeriesStatus,
                x.IsActive,
                x.IsVisible
            });

            // ✅ Series <-> Category MANY-TO-MANY (Join Table: SeriesCategories)
            builder.HasMany(s => s.Categories)
                   .WithMany(c => c.Series)
                   .UsingEntity<Dictionary<string, object>>(
                        "SeriesCategories",
                        j => j.HasOne<Category>()
                              .WithMany()
                              .HasForeignKey("CategoryId")
                              .OnDelete(DeleteBehavior.Restrict),
                        j => j.HasOne<Series>()
                              .WithMany()
                              .HasForeignKey("SeriesId")
                              .OnDelete(DeleteBehavior.Cascade),
                        j =>
                        {
                            j.HasKey("SeriesId", "CategoryId");
                            j.ToTable("SeriesCategories");
                        });
        }
    }
}