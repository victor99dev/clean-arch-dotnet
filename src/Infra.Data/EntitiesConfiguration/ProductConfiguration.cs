using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : EntityConfiguration<Product>
    {
        public ProductConfiguration() : base("products")
        {
        }

        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(p => p.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(p => p.Price).HasPrecision(10, 2)
                    .HasColumnName("price");

            builder.Property(p => p.Stock)
                    .HasColumnName("stock");

            builder.Property(p => p.Image)
                    .HasColumnName("image");

            builder.Property(p => p.CategoryId)
                    .HasColumnName("category_id");

            builder.HasOne(e => e.Category)
                    .WithMany(e => e.Products)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}