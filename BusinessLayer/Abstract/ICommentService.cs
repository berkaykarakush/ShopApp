using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ICommentService: IValidator<Comment>
    {
        Comment GetById(double id);
        List<Comment> GetAll();
        bool Create(Comment entity);
        bool Update(Comment entity);
        bool Delete(Comment entity);
    }
}
