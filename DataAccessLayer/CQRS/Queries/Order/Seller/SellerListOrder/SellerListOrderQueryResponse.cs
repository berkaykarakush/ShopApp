using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerListOrderQueryResponse
    {
        public bool IsSuccess { get; set; }
        public List<Order>? Orders { get; set; }
    }
}