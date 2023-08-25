using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Configurations
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// This method contains database startup data
        /// </summary>
        /// <param name="builder"></param>
        public static void Seed(this ModelBuilder builder)
        {

            //Category
            for (int i = 1; i < 10; i++)
            {
                builder.Entity<Category>().HasData(
                    new Category() { CategoryId = i+111111111, Name = $"category {i}", Url = $"category-{i}" }
                );
            }
                
            //Product
            for (int i = 1; i < 50; i++)
            {
                builder.Entity<Product>().HasData(
                    new Product() { ProductId = i+111111111, Name = $"urun {i}", Url = $"urun-{i}", Price = 10, Description = $"urun aciklamasi {i}", IsApproved = true, CreatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), IsHome = false, Quantity = i, SalesCount = i, UpdatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), ProductImage = "1.jpg"}
                );
            }

            //ProductCategory
            for (int i = 1; i < 10; i++)
            {
                builder.Entity<ProductCategory>().HasData(
                    new ProductCategory() { CategoryId = i + 111111111, ProductId = i + 111111111 }
                );
            }

            //ImageUrls
            for (int i = 1; i < 50; i++)
            {
                for (int j = 1; j < 5; j+=6)
                {
                    builder.Entity<ImageUrl>().HasData(
                    new ImageUrl()
                    {
                        Id = i + j + 111111111,
                        CampaignId = i + 111111111,
                        ProductId = i + 111111111,
                        Url = "1.jpg"
                    });
                }
            }

            //Campaings
            for (int i = 1; i < 50; i++)
            {
                builder.Entity<Campaign>().HasData(
                new Campaign()
                {
                    CampaignId = i + 111111111,
                    CampaignImage = "1.jpg",
                    Code = "23sdasdasd",
                    CreatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    Description = $"Description: {i + 111111111}",
                    IsHome = true,
                    Name = $"Campaign {i + 111111111}"
                });
            }

        }
    }
}
