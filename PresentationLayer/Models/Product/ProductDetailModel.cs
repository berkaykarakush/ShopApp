using EntityLayer;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Models
{
    public class ProductDetailModel
    {
        public ProductVM Product { get; set; }
        public CreateCommentVM Comment { get; set; }
        public ICollection<CommentVM>? Comments { get; set; }
    }
}
