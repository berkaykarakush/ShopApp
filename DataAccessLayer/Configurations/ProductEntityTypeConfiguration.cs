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

            //Description
            builder.Property(p => p.Description).IsRequired();

            //Url
            builder.Property(p => p.Url).IsRequired();


            //ImageUrl
            //builder.Property(p => p.ImageUrl).IsRequired();

            builder.HasMany(p => p.ImageUrls)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Comments)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
