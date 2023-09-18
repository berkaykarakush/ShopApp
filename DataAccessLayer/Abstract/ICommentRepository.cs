using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface ICommentRepository: IRepository<Comment>
    {
        List<Comment> GetAllCommentByStore(double storeId);
    }
}
