using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface IStoreRepository: IRepository<Store>
    {
        Store GetByIdWithImageUrls(double id);
        Store GetByUserIdWithImageUrls(string userId);
    }
}
