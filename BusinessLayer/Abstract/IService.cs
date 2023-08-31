namespace BusinessLayer.Abstract
{
    public interface IService<T>
    {
        T GetById(double id);
        List<T> GetAll();
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
