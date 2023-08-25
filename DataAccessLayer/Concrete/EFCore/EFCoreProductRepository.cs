using DataAccessLayer.Abstract;
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
        public Product GetByIdWithCategories(double id)
        {
            return ShopContext.Products
                .Where(p => p.ProductId == id)
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .Include(p => p.ImageUrls)
                .FirstOrDefault();
        }

        public int GetCountByCategory(string category)
        {
            var products = ShopContext.Products
                .Include(p => p.ImageUrls)
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

        public int GetCountTopSalesProduct()
        {
            return ShopContext.Products
                .Include (p => p.ImageUrls)
                .Where(p => p.IsApproved)
                .OrderByDescending(p => p.SalesCount)
                .Count();
        }

        public List<Product> GetHomePageProducts()
        {
            return ShopContext.Products
                .Include(p => p.ImageUrls)
                .Where(p => p.IsApproved && p.IsHome)
                .ToList();
        }

        public List<Product> GetPopularProducts()
        {
             return ShopContext.Products
                .Include(p => p.ImageUrls)
                .ToList();
        }

        public Product GetProductDetails(string url)
        {
            var q = ShopContext.Products
                .Where(p => p.Url == url)
                .Include(p => p.ProductCategories)
                .ThenInclude(p => p.Category)
                .Include(p => p.ImageUrls)
                .AsQueryable();

            return q.FirstOrDefault();
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            var products = ShopContext.Products
                .Include(p => p.ImageUrls)
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
                .Include(p => p.ImageUrls)
                .Where(p => p.IsApproved && (p.Name.ToLower().Contains(searchString) || p.Description.ToLower().Contains(searchString)))
                .AsQueryable();

            return products.ToList();
        }

        public List<Product> GetTopSalesProducts(int page, int pageSize)
        {
            var products = ShopContext.Products
                .Include(p => p.ImageUrls)
                .OrderByDescending(p => p.SalesCount)
                .AsQueryable();

            return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Product> GetTopSalesProductsWithCategory(string name, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product entity, List<double> categoryIds)
        {
            var product = ShopContext.Products
                .Include (p => p.ImageUrls)
                .Include(p => p.ProductCategories)
                .FirstOrDefault(p => p.ProductId == entity.ProductId);

            if (product != null)
            {
                product.Name = entity.Name;
                product.Url = entity.Url;
                product.Price = entity.Price;
                product.Quantity = entity.Quantity;
                product.Description = entity.Description;
                product.IsHome = entity.IsHome;
                product.IsApproved = entity.IsApproved;
                product.UpdatedDate = entity.UpdatedDate;

                product.ImageUrls = entity.ImageUrls.Select(i => new ImageUrl()
                {
                    ProductId = entity.ProductId,
                    Product = product,

                }).ToList();

                product.ProductCategories = categoryIds.Select(c => new ProductCategory()
                {
                    ProductId = entity.ProductId,
                    CategoryId = c
                }).ToList();
                return true;
            }
            return false;
        }
    }
}
