using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ICategory2Service: IValidator<Category2>, IService<Category2>
    {
        Category2 GetByIdWithProducts(double category2Id);
        void DeleteFromCategory2(double productId, double category2Id);
    }
}
