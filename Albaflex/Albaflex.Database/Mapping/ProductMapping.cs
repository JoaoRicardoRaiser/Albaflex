using Albaflex.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albaflex.Database.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.HasIndex(x => x.Code).IsUnique();
            builder.Property(x => x.Code).HasColumnName("code").IsRequired();
            builder.Property(x => x.Description).HasColumnName("name").IsRequired();
            builder.Property(x => x.Price).HasColumnName("value").IsRequired();
            builder.Property(x => x.Type).HasColumnName("type").HasConversion<string>().IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").IsRequired();
        }
    }
}
