using BusinessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class Category2Manager : ICategory2Service
    {
        public string ErrorMessage { get; set; } = string.Empty;

        public bool Create(Category2 entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category2 entity)
        {
            throw new NotImplementedException();
        }

        public List<Category2> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category2 GetById(double id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category2 entity)
        {
            throw new NotImplementedException();
        }

        public bool Validation(Category2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
