using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreCommentRepository : EFCoreGenericRepository<Comment>, ICommentRepository
    {
        public EFCoreCommentRepository(DbContext context) : base(context)
        {
        }
    }
}
