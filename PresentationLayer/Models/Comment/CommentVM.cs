using EntityLayer;

namespace PresentationLayer.Models
{
    public class CommentVM
    {
        public double CommentId { get; set; }
        public double ProductId { get; set; }
        public ProductVM? Product { get; set; }
        public string? UserId { get; set; }
        public string? UserFirstname { get; set; }
        public string? UserLastname { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CommentRate { get; set; }
    }
}
