using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EFCore;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreProductRepository : EFCoreGenericRepository<Product>, IProductRepository
    {
        public EFCoreProductRepository(ShopContext context) : base(context)
        {

        }
        private ShopContext ShopContext
        {
            get { return _context as ShopContext; }
        }
        public Product GetByIdWithCategories(int id)
        {
            return ShopContext.Products
                .Where(p => p.ProductId == id)
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefault();
        }

        public int GetCountByCategory(string category)
        {
            var products = ShopContext.Products
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

        public List<Product> GetHomePageProducts()
        {
            return ShopContext.Products
                .Where(p => p.IsApproved && p.IsHome)
                .ToList();
        }

        public List<Product> GetPopularProducts()
        {
             return ShopContext.Products.ToList();
        }

        public Product GetProductDetails(string url)
        {
            return ShopContext.Products
                .Where(p => p.Url == url)
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefault();
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            var products = ShopContext.Products
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

        public List<Product> GetSearchResult(string searchString)
        {
            var products = ShopContext.Products
                .Where(p => p.IsApproved && (p.Name.ToLower().Contains(searchString) || p.Description.ToLower().Contains(searchString)))
                .AsQueryable();

            return products.ToList();
        }

        public List<Product> GetTop5Products()
        {
            throw new NotImplementedException();
        }
        public void Update(Product entity, int[] categoryIds)
        {
            var product = ShopContext.Products
                .Include(p => p.ProductCategories)
                .FirstOrDefault(p => p.ProductId == entity.ProductId);

            if (product != null)
            {
                product.Name = entity.Name;
                product.Price = entity.Price;
                product.Url = entity.Url;
                product.Description = entity.Description;
                product.ImageUrl= entity.ImageUrl;  
                product.IsHome = entity.IsHome;
                product.IsApproved = entity.IsApproved;

                product.ProductCategories = categoryIds.Select(c => new ProductCategory()
                {
                    ProductId = entity.ProductId,
                    CategoryId = c
                }).ToList();
            }
        }
    }
}
