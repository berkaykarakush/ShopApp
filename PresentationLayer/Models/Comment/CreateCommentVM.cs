namespace PresentationLayer.Models
{
    public class CreateCommentVM
    {
        public double CommentId { get; set; }
        public double ProductId { get; set; }
        public ProductVM? Product { get; set; }
        public string? UserId { get; set; }
        public string? UserFirstname { get; set; }
        public string? UserLastname { get; set; }
        public string? Description { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
    }
}
