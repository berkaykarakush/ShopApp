using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class CartEntityTypeConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.CartId);

            builder.Property(c => c.UserId).IsRequired();

            builder.HasMany(c => c.CartItems)
                .WithOne(c => c.Cart)
                .HasForeignKey(c => c.CartId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
