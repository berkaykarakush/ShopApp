using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreCommentRepository : EFCoreGenericRepository<Comment>, ICommentRepository
    {
        public EFCoreCommentRepository(ShopContext context) : base(context) { }

        private ShopContext ShopContext 
        { 
            get { return _context as ShopContext;} 
        }
        public List<Comment> GetAllCommentByStore(double storeId)
        {
            return ShopContext.Comments
                                .Where(c => c.StoreId == storeId)
                                .ToList();
        }
    }
}
