using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListProductQueryResponse
    {
        public PageInfo? PageInfo { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public bool IsSuccess { get; set; } = false;
    }
}