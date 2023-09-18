using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminEditCommentQueryResponse
    {
        public double CommentId { get; set; }
        public double? ProductId { get; set; }
        public Product? Product { get; set; }
        public string? UserId { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsSuccess { get; set; }
    }
}