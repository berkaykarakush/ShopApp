using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListCommentQueryResponse
    {
        public List<Comment>? Comments { get; set; } = new List<Comment>();
        public bool IsSuccess { get; set; }
    }
}