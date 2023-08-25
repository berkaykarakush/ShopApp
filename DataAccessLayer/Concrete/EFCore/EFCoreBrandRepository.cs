using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreBrandRepository : EFCoreGenericRepository<Brand>, IBrandRepository
    {
        public EFCoreBrandRepository(DbContext context) : base(context)
        {
        }
    }
}
