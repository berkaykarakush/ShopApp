using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListCommentQueryResponse
    {
        public ICollection<Comment> Comments { get; set; }
        public bool IsSuccess { get; set; }
    }
}