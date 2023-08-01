using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreCategoryRepository : EFCoreGenericRepository<Category, ShopContext>, ICategoryRepository
    {
        public void DeleteFromCategory(int productId, int categoryId)
        {
            using (var context = new ShopContext())
            {
                var cmd = "delete from productcategory where ProductId=@p0 and CategoryId=@p1";
                context.Database.ExecuteSqlRaw(cmd, productId, categoryId);
            }
        }

        public Category GetByIdWithProducts(int categoryId)
        {
            using (var context = new ShopContext())
            {
                return context.Categories
                    .Where(p => p.CategoryId == categoryId)
                    .Include(p => p.ProductCategories)
                    .ThenInclude(p => p.Product)
                    .FirstOrDefault();
            }
        }

        public List<Product> GetPopularCategories()
        {
            throw new NotImplementedException();
        }
    }
}
