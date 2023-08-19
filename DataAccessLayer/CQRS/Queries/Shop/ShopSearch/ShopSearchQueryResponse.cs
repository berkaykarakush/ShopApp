using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopSearchQueryResponse
    {
        public ShopSearchQueryResponse()
        {
            Products = new List<Product>();
        }
        public List<Product> Products { get; set; }
        public bool IsSuccess { get; set; }
    }
}