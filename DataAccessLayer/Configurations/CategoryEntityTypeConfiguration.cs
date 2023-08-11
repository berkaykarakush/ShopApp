using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Primary key
            builder.HasKey(c => c.CategoryId);

            //name
            builder.Property(c => c.Name).IsRequired();

            //url
            builder.Property(c => c.Url).IsRequired();

        }
    }
}
