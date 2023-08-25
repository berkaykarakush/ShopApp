using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //Primary Key
            builder.HasKey(c => c.OrderId);


            //Order Number
            builder.Property(o => o.OrderNumber).IsRequired();

            //user
            builder.Property(o => o.UserId).IsRequired();
            builder.Property(o => o.FirstName).IsRequired();
            builder.Property(o => o.LastName).IsRequired();
            builder.Property(o => o.Email).IsRequired();
            builder.Property(o => o.Phone).IsRequired();
            builder.Property(o => o.Address).IsRequired();
            builder.Property(o => o.City).IsRequired();

            //Order Date
            builder.Property(o => o.OrderDate).HasDefaultValueSql("getdate()");
        }
    }
}
