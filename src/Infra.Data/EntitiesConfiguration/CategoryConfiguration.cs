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
                new Category (new Guid(), "School Supplies"),
                new Category (new Guid(), "Electronics"),
                new Category (new Guid(), "Clothing and accessories"),
                new Category (new Guid(), "Toy")
            );
        }
    }
}