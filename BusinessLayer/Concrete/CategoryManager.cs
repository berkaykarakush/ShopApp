using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Create(Category entity)
        {
            //TODO Is Kurallari
            _unitOfWork.Categories.Create(entity);
            _unitOfWork.Save();
        }

        public void Delete(Category entity)
        {
            //TODO is kurallari 
            _unitOfWork.Categories.Delete(entity);
            _unitOfWork.Save();
        }

        public void DeleteFromCategory(int productId, int categoryId)
        {
            _unitOfWork.Categories.DeleteFromCategory(productId, categoryId);
            _unitOfWork.Save();
        }

        public List<Category> GetAll()
        {
           return _unitOfWork.Categories.GetAll();
        }

        public Category GetById(int id)
        {
            return _unitOfWork.Categories.GetById(id);
        }

        public Category GetByIdWithProducts(int categoryId)
        {
            return _unitOfWork.Categories.GetByIdWithProducts(categoryId);
        }

        public void Update(Category entity)
        {
            //TODO Is kurallari
            _unitOfWork.Categories.Update(entity);
            _unitOfWork.Save();
        }

        public bool Validation(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
