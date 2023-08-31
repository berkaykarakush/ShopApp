using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ICategory2Service: IValidator<Category2>
    {
        Category2 GetById(double id);
        List<Category2> GetAll();
        bool Create(Category2 entity);
        bool Update(Category2 entity);
        void Delete(Category2 entity);
    }
}
