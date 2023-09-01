namespace PresentationLayer.Models
{
    public class ProductDetailModel
    {
        public ProductVM? Product { get; set; }
        public CreateCommentVM? Comment { get; set; }
        public List<CommentVM>? Comments { get; set; }
    }
}
