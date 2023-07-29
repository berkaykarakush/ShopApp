using Azure;
using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreProductRepository : EFCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
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
    }
}
