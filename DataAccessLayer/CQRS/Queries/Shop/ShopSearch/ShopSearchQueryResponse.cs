using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopSearchQueryResponse
    {
        public List<Product>? Products { get; set; } = new List<Product>();
        public bool IsSuccess { get; set; } = false;
    }
}