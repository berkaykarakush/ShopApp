using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class CartItemEntityTypeConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            //Primary Key
            builder.HasKey(c => c.CartItemId);

            builder.Property(c => c.Quantity).IsRequired();
            builder.Property(c => c.CartId).IsRequired();
            builder.Property(c => c.ProductId).IsRequired();
        }
    }
}
