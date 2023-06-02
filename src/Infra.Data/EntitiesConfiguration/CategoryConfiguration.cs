using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Name)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.HasData(
                new Category (Guid.NewGuid(), "School Supplies"),
                new Category (Guid.NewGuid(), "Electronics"),
                new Category (Guid.NewGuid(), "Clothing and accessories"),
                new Category (Guid.NewGuid(), "Toy")
            );
        }
    }
}