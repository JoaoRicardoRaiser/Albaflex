using Albaflex.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albaflex.Database.Mapping
{
    public class TissueMapping : IEntityTypeConfiguration<Tissue>
    {
        public void Configure(EntityTypeBuilder<Tissue> builder)
        {
            builder.ToTable("tissue");
            builder.HasKey(x => x.Code);
            builder.HasIndex(x => x.Code);
            builder.Property(x => x.Code).HasColumnName("code").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x => x.Value).HasColumnName("value").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").IsRequired();

            builder.Ignore(x => x.Id);
        }
    }
}
