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
            builder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, Name = "Telefon", Url = "telefon" },
                new Category() { CategoryId = 2, Name = "Bilgisayar", Url = "bilgisayar" },
                new Category() { CategoryId = 3, Name = "Elektronik", Url = "elektorik" },
                new Category() { CategoryId = 4, Name = "Beyaz Eşya", Url = "beyaz-esya" }
            );

            //Product
            builder.Entity<Product>().HasData(
                new Product() { ProductId = 1, Name = "Iphone 11", Url = "iphone-11", Price = 20000, Description = "iyi telefon", ImageUrl = "1.jpg", IsApproved = true },
                new Product() { ProductId = 2, Name = "Iphone 11 pro", Url = "iphone-11-pro", Price = 21000, Description = "iyi telefon", ImageUrl = "2.jpg", IsApproved = true },
                new Product() { ProductId = 3, Name = "Iphone 12", Url = "iphone-12", Price = 22000, Description = "iyi telefon", ImageUrl = "1.jpg", IsApproved = true },
                new Product() { ProductId = 4, Name = "Iphone 12 pro", Url = "iphone-12-pro", Price = 23000, Description = "iyi telefon", ImageUrl = "2.jpg", IsApproved = true },
                new Product() { ProductId = 5, Name = "Iphone 12 pro max", Url = "iphone-12-pro-max", Price = 24000, Description = "iyi telefon", ImageUrl = "1.jpg", IsApproved = true },
                new Product() { ProductId = 6, Name = "Iphone 13", Url = "iphone-13", Price = 25000, Description = "iyi telefon", ImageUrl = "2.jpg", IsApproved = true },
                new Product() { ProductId = 7, Name = "Iphone 13 pro", Url = "iphone-13-pro", Price = 26000, Description = "iyi telefon", ImageUrl = "1.jpg", IsApproved = true },
                new Product() { ProductId = 8, Name = "Iphone 13 pro max", Url = "iphone-13-pro-max", Price = 27000, Description = "iyi telefon", ImageUrl = "2.jpg", IsApproved = true }
            );

            //ProductCategory
            builder.Entity<ProductCategory>().HasData(
                new ProductCategory() { CategoryId = 1, ProductId = 1 },
                new ProductCategory() { CategoryId = 1, ProductId = 2 },
                new ProductCategory() { CategoryId = 2, ProductId = 1 },
                new ProductCategory() { CategoryId = 2, ProductId = 2 },
                new ProductCategory() { CategoryId = 3, ProductId = 1 },
                new ProductCategory() { CategoryId = 3, ProductId = 2 },
                new ProductCategory() { CategoryId = 4, ProductId = 1 },
                new ProductCategory() { CategoryId = 4, ProductId = 2 }
            );
        }
    }
}
