using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreCategory2Repository : EFCoreGenericRepository<Category2>, ICategory2Repository
    {
        public EFCoreCategory2Repository(ShopContext context) : base(context)
        {
        }
        private ShopContext ShopContext { get { return _context as ShopContext; } }

        public void DeleteFromCategory(double productId, double category2Id)
        {
            //TODO DeleteFromCategory
            throw new NotImplementedException();
        }

        public Category2 GetByIdWithProducts(double category2Id)
        {
            return ShopContext.Categories2
                .Where(p => p.Category2Id == category2Id)
                .Include(p => p.Products)
                .FirstOrDefault();
        }

        public bool GetByName(string name)
        {
            return ShopContext.Categories2.Any(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
