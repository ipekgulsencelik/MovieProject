using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Persistence.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");

            // Comment
            builder.Property(x => x.Comment)
                   .HasMaxLength(2000);

            // ✅ Rating (decimal precision) — uyarıyı bitirir
            builder.Property(x => x.Rating)
                   .HasPrecision(3, 1); // 0.0 - 10.0

            // ReviewDate (UTC default)
            builder.Property(x => x.ReviewDate)
                   .HasDefaultValueSql("GETUTCDATE()");

            // ReviewStatus enum -> int + default
            builder.Property(x => x.ReviewStatus)
                   .HasConversion<int>()
                   .HasDefaultValue(ReviewStatus.Pending);

            // Relationship: Review -> Film (Many reviews to one film)
            builder.HasOne(x => x.Film)
                   .WithMany(x => x.Reviews)
                   .HasForeignKey(x => x.FilmId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.FilmId);
            builder.HasIndex(x => new { x.ReviewStatus, x.ReviewDate });
        }
    }
}