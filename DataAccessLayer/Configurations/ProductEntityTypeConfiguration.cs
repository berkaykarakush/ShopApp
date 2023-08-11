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
            builder.Property(p => p.Name).HasMaxLength(80);
            
            //Price
            builder.Property(p => p.Price).IsRequired();

            //Quantity
            builder.Property(p => p.Quantity).IsRequired();

            //DateAdded
            builder.Property(p => p.CreatedDate).HasDefaultValueSql("getdate()");

            //Description
            builder.Property(p => p.Description).IsRequired();

            //Url
            builder.Property(p => p.Url).IsRequired();


            //ImageUrl
            builder.Property(p => p.ImageUrl).IsRequired();
        }
    }
}
