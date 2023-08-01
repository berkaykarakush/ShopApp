using Azure;
using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreProductRepository : EFCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public Product GetByIdWithCategories(int id)
        {
            using (var context = new ShopContext())
            {
                return context.Products
                    .Where(p => p.ProductId == id)
                    .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                    .FirstOrDefault();
            }
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products
                    .Where(p => p.IsApproved)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                       .Include(p => p.ProductCategories)
                                       .ThenInclude(p => p.Category)
                                       .Where(p => p.ProductCategories.Any(
                                           a => a.Category.Url == category.ToLower()));
                }

                return products.Count();
            }
        }

        public List<Product> GetHomePageProducts()
        {
            using (var context = new ShopContext())
            {
                return context.Products
                    .Where(p => p.IsApproved && p.IsHome)
                    .ToList();
            }
        }

        public List<Product> GetPopularProducts()
        {
            using (var context = new ShopContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProductDetails(string url)
        {
            using (var context = new ShopContext())
            {
                return context.Products
                    .Where(p => p.Url == url)
                    .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                    .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products
                    .Where(p => p.IsApproved)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(name))
                {
                    products = products
                                       .Include(p => p.ProductCategories)
                                       .ThenInclude(p => p.Category)
                                       .Where(p => p.ProductCategories.Any(
                                           a => a.Category.Url == name.ToLower()));
                }

                return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
            }
        }

        public List<Product> GetSearchResult(string searchString)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products
                    .Where(p => p.IsApproved && (p.Name.ToLower().Contains(searchString) || p.Description.ToLower().Contains(searchString)))
                    .AsQueryable();

                return products.ToList();
            }
        }

        public List<Product> GetTop5Products()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity, int[] categoryIds)
        {
            using (var context = new ShopContext())
            {
                var product = context.Products
                    .Include(p => p.ProductCategories)
                    .FirstOrDefault(p => p.ProductId == entity.ProductId);

                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Price = entity.Price;
                    product.Url = entity.Url;
                    product.Description = entity.Description;
                    product.ImageUrl= entity.ImageUrl;  

                    product.ProductCategories = categoryIds.Select(c => new ProductCategory()
                    {
                        ProductId = entity.ProductId,
                        CategoryId = c
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }
    }
}
