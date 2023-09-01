using EntityLayer;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditProductCommandResponse
    {
        public List<ImageUrl>? ImageUrls { get; set; } = new List<ImageUrl>();
        public double ProductId { get; set; }
        public bool IsSuccess { get; set; } 
    }
}