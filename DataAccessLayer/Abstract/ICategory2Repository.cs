using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface ICategory2Repository: IRepository<Category2>
    {
        Category2 GetByIdWithProducts(double category2Id);
        bool GetByName(string name);
    }
}
