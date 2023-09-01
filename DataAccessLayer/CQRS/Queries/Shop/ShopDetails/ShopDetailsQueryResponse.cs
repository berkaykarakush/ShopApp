using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopDetailsQueryResponse
    {
        public Product? Product { get; set; }
        public List<Comment>? Comments { get; set; } = new List<Comment>();
        public bool IsSuccess { get; set; } 
    }
}