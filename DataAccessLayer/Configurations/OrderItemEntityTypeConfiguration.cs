using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            //Primary key
            builder.HasKey(o => o.OrderItemId);

            //Price
            builder.Property(o => o.Price).IsRequired();

            //Quantity
            builder.Property(o => o.Quantity).IsRequired();
        }
    }
}
