using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EFCore
{
    public static class SeedData
    {
        public static void Seed()
        {

            var context = new ShopContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }
                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(productCategories);
                }
            }
            context.SaveChanges();
        }

        private static Category[] Categories =
        {
            new Category() { Name = "Telefon", Url= "telefon" },
            new Category() { Name = "Bilgisayar", Url= "bilgisayar" },
            new Category() { Name = "Elektronik", Url= "elektorik" },
            new Category() { Name = "Beyaz Eşya", Url= "beyaz-esya" }
        };
        private static Product[] Products = {
            new Product() { Name = "Iphone 11", Url="iphone-11", Price = 20000, Description = "iyi telefon", ImageUrl = "1.jpg", IsApproved = true },
            new Product() { Name = "Iphone 11 pro", Url="iphone-11-pro", Price = 21000, Description = "iyi telefon", ImageUrl = "2.jpg", IsApproved = true },
            new Product() { Name = "Iphone 12", Url="iphone-12", Price = 22000, Description = "iyi telefon", ImageUrl = "1.jpg", IsApproved = true },
            new Product() { Name = "Iphone 12 pro", Url="iphone-12-pro", Price = 23000, Description = "iyi telefon", ImageUrl = "2.jpg", IsApproved = true },
            new Product() { Name = "Iphone 12 pro max", Url="iphone-12-pro-max", Price = 24000, Description = "iyi telefon", ImageUrl = "1.jpg", IsApproved = true },
            new Product() { Name = "Iphone 13", Url="iphone-13", Price = 25000, Description = "iyi telefon", ImageUrl = "2.jpg", IsApproved = true },
            new Product() { Name = "Iphone 13 pro", Url="iphone-13-pro", Price = 26000, Description = "iyi telefon", ImageUrl = "1.jpg", IsApproved = true },
            new Product() { Name = "Iphone 13 pro max", Url="iphone-13-pro-max", Price = 27000, Description = "iyi telefon", ImageUrl = "2.jpg", IsApproved = true }
        };
        private static ProductCategory[] productCategories = { 
            new ProductCategory() {Category = Categories[0], Product= Products[0]},
            new ProductCategory() {Category = Categories[1], Product= Products[1]},
            new ProductCategory() {Category = Categories[2], Product= Products[2]},
            new ProductCategory() {Category = Categories[1], Product= Products[3]},
            new ProductCategory() {Category = Categories[2], Product= Products[4]},
            new ProductCategory() {Category = Categories[1], Product= Products[5]},
            new ProductCategory() {Category = Categories[2], Product= Products[6]},
            new ProductCategory() {Category = Categories[0], Product= Products[7]},

        };
    }
}
