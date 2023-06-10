using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : EntityConfiguration<Category>
    {
        public CategoryConfiguration() : base("categories")
        {
        }

        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsRequired();
        }
    }
}