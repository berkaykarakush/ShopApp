using EntityLayer;

namespace DataAccessLayer.CQRS.Commands
{
    public class AdminEditProductCommandResponse
    {
        public List<ImageUrl>? ImageUrls { get; set; } = new List<ImageUrl>();
        public double ProductId { get; set; }
        public bool IsSuccess { get; set; }
    }
}