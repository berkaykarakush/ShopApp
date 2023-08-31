using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService: IValidator<Category>, IService<Category>
    {
        Category GetByIdWithProducts(double categoryId);
        void DeleteFromCategory(double productId, double categoryId);
    }
}
