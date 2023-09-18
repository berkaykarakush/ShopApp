using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerListCommentQueryResponse
    {
        public List<Comment>? Comments { get; set; }
        public bool IsSuccess { get; set; }
    }
}