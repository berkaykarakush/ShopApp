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
                .Include(p => p.Category)
                .Include(p => p.ImageUrls)
                .Include(p => p.Brand)
                .Include(p => p.Comments)
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
                                .Include(p => p.Category)
                                .Where(p => p.Category.Url == category.ToLower());
            }

            return products.Count();
        }

        public int GetCountByCategory2(string category2)
        {
            var products = ShopContext.Products
                .Include(p => p.ImageUrls)
                .Where(p => p.IsApproved)
                .AsQueryable();

            if (!string.IsNullOrEmpty(category2))
            {
                products = products.Include(p => p.Category2)
                                    .Where(p => p.Category2.Url == category2.ToLower());
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
                .Include(p => p.Brand)
                .Where(p => p.IsApproved && p.IsHome)
                .ToList();
        }

        public List<Product> GetPopularProducts()
        {
             return ShopContext.Products
                .Include(p => p.Brand)
                .Include(p => p.ImageUrls)
                .ToList();
        }

        public Product GetProductDetails(string url)
        {
            return ShopContext.Products
                .Where(p => p.Url == url)
                .Include(p => p.ImageUrls)
                .Include(p => p.Brand)
                .Include(p => p.Comments)
                .Include(p => p.Category)
                .Include(p => p.Category2)
                .FirstOrDefault();

        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            var products = ShopContext.Products
                .Include(p => p.ImageUrls)
                .Include(p => p.Brand)
                .Include(p => p.Comments)
                .Where(p => p.IsApproved)
                .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                products = products
                                    .Include(p => p.Category)
                                    .Where(p => p.Category.Url == name.ToLower());
            }

            return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
        }

        public List<Product> GetProductsByCategory2(string name, int page, int pageSize)
        {
            var products = ShopContext.Products
                .Include(p => p.ImageUrls)
                .Include(p => p.Brand)
                .Include(p => p.Comments)
                .Where(p => p.IsApproved)
                .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                products = products.Include(p => p.Category2)
                                    .Where(p => p.Category2.Url == name.ToLower());
            }

            return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Product> GetSearchResult(string searchString)
        {
            var products = ShopContext.Products
                .Include(p => p.ImageUrls)
                .Include(p => p.Brand)
                .Where(p => p.IsApproved && (p.Name.ToLower().Contains(searchString) || p.Description.ToLower().Contains(searchString)))
                .AsQueryable();

            return products.ToList();
        }

        public List<Product> GetTopSalesProducts(int page, int pageSize)
        {
            var products = ShopContext.Products
                .Include(p => p.ImageUrls)
                .Include(p => p.Brand)
                .OrderByDescending(p => p.SalesCount)
                .AsQueryable();

            return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Product> GetTopSalesProductsWithCategory(string name, int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
