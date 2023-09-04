using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DataAccessLayer.Configurations
{
    public class ImageurlTypeConfiguration : IEntityTypeConfiguration<ImageUrl>
    {
        public void Configure(EntityTypeBuilder<ImageUrl> builder)
        {
            //Primary Key
            builder.HasKey(c => c.ImageUrlId);

            builder.HasOne<Store>()
                .WithMany(i => i.ImageUrls)
                .HasForeignKey(i => i.StoreId);

            builder.HasOne<Product>()
                .WithMany(i => i.ImageUrls)
                .HasForeignKey(i => i.ProductId);
        }
    }
}
