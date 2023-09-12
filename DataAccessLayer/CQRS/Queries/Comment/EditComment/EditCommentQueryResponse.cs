using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditCommentQueryResponse
    {
        public double CommentId { get; set; }
        public double? ProductId { get; set; }
        public Product? Product { get; set; }
        public string? UserId { get; set; }
        public string? Description { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public bool IsSuccess { get; set; }
    }
}