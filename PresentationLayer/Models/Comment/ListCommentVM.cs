using EntityLayer;

namespace PresentationLayer.Models  
{
    public class ListCommentVM
    {
        public ICollection<CommentVM> Comments { get; set; }
    }
}
