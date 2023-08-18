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
        public void DeleteFromCategory(double productId, double categoryId)
        {
            var cmd = "delete from ProductCategories where ProductId=@p0 and CategoryId=@p1";
            ShopContext.Database.ExecuteSqlRaw(cmd, productId, categoryId);
        }

        public Category GetByIdWithProducts(double categoryId)
        {
            return ShopContext.Categories
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.ProductCategories)
                .ThenInclude(p => p.Product)
                 .FirstOrDefault();
        }

        public bool GetByName(string name)
        {
            return ShopContext.Categories.Any(c => c.Name.ToLower() == name.ToLower());    
        }

        public List<Product> GetPopularCategories()
        {
            throw new NotImplementedException();
        }
    }
}
