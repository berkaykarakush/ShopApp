using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService: IValidator<Category>
    {
        Category GetById(int id);
        Category GetByIdWithProducts(int categoryId);
        List<Category> GetAll();
        bool Create(Category entity);
        bool Update(Category entity);
        void Delete(Category entity);
        void DeleteFromCategory(int productId, int categoryId);
    }
}
