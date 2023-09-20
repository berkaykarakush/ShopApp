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
                new Category() { CategoryId = 111111111, Name = "Woman", Url = "woman" },
                new Category() { CategoryId = 111111112, Name = "Man", Url = "man" },
                new Category() { CategoryId = 111111113, Name = "Mom & Child", Url = "mom-child" },
                new Category() { CategoryId = 111111114, Name = "Home & Furniture", Url = "home-furniture" },
                new Category() { CategoryId = 111111115, Name = "Supermarket", Url = "supermarket" },
                new Category() { CategoryId = 111111116, Name = "Cosmetics", Url = "cosmetics" },
                new Category() { CategoryId = 111111117, Name = "Shoe & Bag", Url = "shoe-bag" },
                new Category() { CategoryId = 111111118, Name = "Electronics", Url = "electronics" },
                new Category() { CategoryId = 111111119, Name = "Sport & Outdoor", Url = "sport-outdoor" },
                new Category() { CategoryId = 111111120, Name = "Book & Instrument", Url = "book-instrument" }
            );
            for (int i = 0; i < 40; i++)
            {
                builder.Entity<Category>().HasData
                (
                    new Category() { CategoryId = i + 111111121, Name = $"category {i}", Url = $"category-{i}", CreatedDate = DateTime.Now }
                );
            }

            //Category2
            for (int i = 0; i < 50; i++)
            {
                builder.Entity<Category2>().HasData
                (
                    new Category2() { Category2Id = i + 111111111, CreatedDate = DateTime.Now, Name = $"category2 {i}", Url = $"category2-{i}", CategoryId = i + 111111111 }
                );
            }

            //Brand
            for (int i = 0; i < 50; i++)
            {
                builder.Entity<Brand>().HasData
                (
                    new Brand()
                    {
                        BrandId = i + 111111111,
                        Name = $"Brand {i}",
                        Url = $"brand-{i}",
                    }
                );
            }

            //Product
            for (int i = 0; i < 50; i++)
            {
                builder.Entity<Product>().HasData(
                    new Product() { ProductId = i+111111111, Name = $"urun {i}", Url = $"urun-{i}", Price = 10, Description = $"urun aciklamasi {i}", IsApproved = true, CreatedDate = DateTime.Now, IsHome = true, Quantity = i, SalesCount = i, UpdatedDate = DateTime.Now, ProductImage = "1.jpg", BrandId = i + 111111111, CategoryId = i + 111111111, Category2Id = i + 111111111, CommentCount = 1, StoreId = i + 111111111, StarCount = 1, ProductRate = 1 }
                );
            }

            //ImageUrls
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 5; j+=6)
                {
                    builder.Entity<ImageUrl>().HasData(
                    new ImageUrl()
                    {
                        ImageUrlId = i + j + 111111111,
                        //CampaignId = i + 111111111,
                        ProductId = i + 111111111,
                        StoreId = i + 111111111,
                        Url = "1.jpg"
                    });
                }
            }
            //Stores
            for (int i = 0; i < 50; i++)
            {
                builder.Entity<Store>().HasData(
                new Store()
                {
                    StoreId = i + 111111111,
                    StoreImage = "1.jpg",
                    CreatedDate = DateTime.Now,
                    StoreName = $"store {i}",
                    StoreUrl = $"store-{i}",
                    CommentCount = 1,
                    StarCount = 1,
                    StoreRate = 1
                });
            }

            //Campaings
            for (int i = 0; i < 50; i++)
            {
                builder.Entity<Campaign>().HasData(
                new Campaign()
                {
                    CampaignId = i + 111111111,
                    CampaignImage = "1.jpg",
                    Code = $"campaign-code-{i + 111111111}",
                    CreatedDate = DateTime.Now,
                    Description = $"Description: {i + 111111111}",
                    Name = $"Campaign {i + 111111111}",
                    DiscountPercentage = i+1
                });
            }

            //Comment
            for (int i = 0; i < 50; i++)
            {
                builder.Entity<Comment>().HasData
                (
                    new Comment()
                    {
                        CommentId = i + 111111111,
                        CreatedDate = DateTime.Now,
                        Description = $"description - {i}",
                        ProductId = i + 111111111,
                        UserId = "2c828e40-4226-42b7-808d-de6f20863d13",
                        UserFirstname = "John",
                        UserLastname = "Doe",
                        CommentRate = 1,
                        StoreId = i + 111111111,
                        SellerAnswer = $"seller answer - {i}"
                    }
                );
            }
        }
    }
}
