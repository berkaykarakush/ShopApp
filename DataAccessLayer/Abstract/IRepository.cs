namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        T GetById(double id);
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
