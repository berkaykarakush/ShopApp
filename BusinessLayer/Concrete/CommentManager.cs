using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string ErrorMessage { get; set; } = string.Empty;

        public bool Create(Comment entity)
        {
            bool isValid = false;
            if (Validation(entity))
            {
                _unitOfWork.Comments.Create(entity);
                _unitOfWork.Save();
                isValid = true;
            }
            return isValid;
        }

        public bool Delete(Comment entity)
        {
            bool isValid = false;

            if (Validation(entity))
            {
                _unitOfWork.Comments.Delete(entity);
                _unitOfWork.Save();
                isValid = true;
            }
            return isValid;
        }

        public List<Comment> GetAll()
        {
            return _unitOfWork.Comments.GetAll();
        }

        public Comment GetById(double id)
        {
            return _unitOfWork.Comments.GetById(id);
        }

        public bool Update(Comment entity)
        {
            bool isValid = false;

            if (Validation(entity))
            {
                _unitOfWork.Comments.Update(entity);
                _unitOfWork.Save();
                isValid = true;
            }
            return isValid;
        }

        public bool Validation(Comment entity)
        {
            bool isValid = true;

            if (entity != null)
            {
                if (string.IsNullOrEmpty(entity.Description))
                {
                    ErrorMessage += "Description is required";
                    isValid = false;
                }

                if (string.IsNullOrEmpty(entity.UserId))
                {
                    ErrorMessage += "UserId is requires";
                    isValid = false;
                }
            }
            else
                isValid = false;

            ErrorMessage += "Error - Null reference!";
            return isValid;
        }
    }
}
