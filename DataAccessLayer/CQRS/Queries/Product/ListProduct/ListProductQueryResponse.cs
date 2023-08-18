using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListProductQueryResponse
    {
        public ListProductQueryResponse()
        {
            Products = new List<Product>();
        }
        public PageInfo? PageInfo { get; set; }
        public List<Product> Products { get; set; }
        public bool Success { get; set; }
    }
}