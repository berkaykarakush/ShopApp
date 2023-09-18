using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminListCommentQueryResponse
    {
        public List<Comment>? Comments { get; set; } = new List<Comment>();
        public bool IsSuccess { get; set; }
    }
}