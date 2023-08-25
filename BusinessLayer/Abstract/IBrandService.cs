using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IBrandService : IValidator<Brand>
    {
        Brand GetById(double id);
        List<Brand> GetAll();
        bool Create(Brand entity);
        bool Update(Brand entity);
        void Delete(Brand entity);
    }
}
