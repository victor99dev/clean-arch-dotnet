using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntitiesConfiguration
{
    public class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        private readonly string _tableName;

        public EntityConfiguration(string tableName)
        {
            _tableName = tableName;
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if (!string.IsNullOrEmpty(_tableName)) builder.ToTable(_tableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");

            builder.Property(x => x.IsActive)
                .HasColumnName("is_active");
        }
    }
}