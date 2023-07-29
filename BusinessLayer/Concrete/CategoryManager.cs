using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Create(Category entity)
        {
            //TODO Is Kurallari
            _categoryRepository.Create(entity);
        }

        public void Delete(Category entity)
        {
            //TODO is kurallari 
            _categoryRepository.Delete(entity);
        }

        public List<Category> GetAll()
        {
           return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void Update(Category entity)
        {
            //TODO Is kurallari
            _categoryRepository.Update(entity);
        }
    }
}
