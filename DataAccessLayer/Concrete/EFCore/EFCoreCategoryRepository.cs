using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreCategoryRepository : EFCoreGenericRepository<Category>, ICategoryRepository
    {
        public EFCoreCategoryRepository(ShopContext context):base(context)
        {
            
        }
        private ShopContext ShopContext 
        {
            get { return _context as ShopContext; }         
        }
        public void DeleteFromCategory(int productId, int categoryId)
        {
            var cmd = "delete from productcategory where ProductId=@p0 and CategoryId=@p1";
            ShopContext.Database.ExecuteSqlRaw(cmd, productId, categoryId);
        }

        public Category GetByIdWithProducts(int categoryId)
        {
            return ShopContext.Categories
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.ProductCategories)
                .ThenInclude(p => p.Product)
                 .FirstOrDefault();
        }

        public List<Product> GetPopularCategories()
        {
            throw new NotImplementedException();
        }
    }
}
