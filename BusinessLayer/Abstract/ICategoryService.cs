using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService: IValidator<Category>
    {
        Category GetById(double id);
        Category GetByIdWithProducts(double categoryId);
        List<Category> GetAll();
        bool Create(Category entity);
        bool Update(Category entity);
        void Delete(Category entity);
        void DeleteFromCategory(double productId, double categoryId);
    }
}
