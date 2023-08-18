using EntityLayer;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditProductCommandResponse
    {
        public EditProductCommandResponse()
        {
            ImageUrls = new List<ImageUrl>();
        }
        public List<ImageUrl> ImageUrls { get; set; }
        public double ProductId { get; set; }
    }
}