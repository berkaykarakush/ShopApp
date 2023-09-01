using EntityLayer;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditProductCommandResponse
    {
        public List<ImageUrl>? ImageUrls { get; set; }
        public double ProductId { get; set; }
        public bool IsSuccess { get; set; } 
    }
}