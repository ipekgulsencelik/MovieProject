using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.Domain.Entities;

namespace Movie.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            // Name
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            // Description
            builder.Property(x => x.Description)
                   .HasMaxLength(1000);

            // DisplayOrder
            builder.Property(x => x.DisplayOrder)
                   .HasDefaultValue(0);

            // ✅ Enum -> int (DB DEFAULT YOK → sentinel uyarısı çıkmaz)
            builder.Property(x => x.CategoryStatus)
                   .HasConversion<int>();

            // Indexes
            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => new { x.CategoryStatus, x.DisplayOrder });
        }
    }
}