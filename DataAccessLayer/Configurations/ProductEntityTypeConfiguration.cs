using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            //Name
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(60);

            //Price
            builder.Property(p => p.Price).IsRequired();

            //DateAdded
            builder.Property(p => p.DateAdded).HasDefaultValueSql("getdate()");
        }
    }
}
