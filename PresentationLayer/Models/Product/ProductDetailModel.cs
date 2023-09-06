namespace PresentationLayer.Models
{
    public class ProductDetailModel
    {
        public ProductVM? Product { get; set; }
        public CreateCommentVM? Comment { get; set; }
        public List<CommentVM>? Comments { get; set; }
        public bool Rate1 { get; set; }
        public bool Rate2 { get; set; }
        public bool Rate3 { get; set; }
        public bool Rate4 { get; set; }
        public bool Rate5 { get; set; }
        public double ProductRate { get; set; }
    }
}
