using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.Domain.Entities;

namespace Movie.Persistence.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable("Films");

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.CoverImageUrl)
                   .HasMaxLength(500);

            builder.Property(x => x.Description)
                   .HasMaxLength(2000);

            builder.Property(x => x.Rating)
                   .HasPrecision(3, 1);

            // ✅ Film <-> Category MANY-TO-MANY (Join Table: FilmCategories)
            builder.HasMany(f => f.Categories)
                   .WithMany(c => c.Films)
                   .UsingEntity<Dictionary<string, object>>(
                        "FilmCategories",
                        j => j.HasOne<Category>()
                              .WithMany()
                              .HasForeignKey("CategoryId")
                              .OnDelete(DeleteBehavior.Restrict),
                        j => j.HasOne<Film>()
                              .WithMany()
                              .HasForeignKey("FilmId")
                              .OnDelete(DeleteBehavior.Cascade),
                        j =>
                        {
                            j.HasKey("FilmId", "CategoryId");
                            j.ToTable("FilmCategories");
                        });
        }
    }
}