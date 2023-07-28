using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
                }
            }
            context.SaveChanges();
        }

        private static Category[] Categories =
        {
            new Category() { Name = "Telefon" },
            new Category() { Name = "Bilgisayar" },
            new Category() { Name = "Elektrinik" }
        };
        private static Product[] Products = {
            new Product() { Name = "Iphone 11", Price = 20000, Description = "iyi telefon", ImageUrl = "1.jpg", IsApproved = true },
            new Product() { Name = "Iphone 11 pro", Price = 21000, Description = "iyi telefon", ImageUrl = "2.jpg", IsApproved = true },
            new Product() { Name = "Iphone 12", Price = 22000, Description = "iyi telefon", ImageUrl = "1.jpg", IsApproved = true },
            new Product() { Name = "Iphone 12 pro", Price = 23000, Description = "iyi telefon", ImageUrl = "2.jpg", IsApproved = true },
            new Product() { Name = "Iphone 12 pro max", Price = 24000, Description = "iyi telefon", ImageUrl = "1.jpg", IsApproved = true },
            new Product() { Name = "Iphone 13", Price = 25000, Description = "iyi telefon", ImageUrl = "2.jpg", IsApproved = true },
            new Product() { Name = "Iphone 13 pro", Price = 26000, Description = "iyi telefon", ImageUrl = "1.jpg", IsApproved = true },
            new Product() { Name = "Iphone 13 pro max", Price = 27000, Description = "iyi telefon", ImageUrl = "2.jpg", IsApproved = true }

        };
    }
}
