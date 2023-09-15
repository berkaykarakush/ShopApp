using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerDetailOrderQueryResponse
    {
        public bool IsSuccess { get; set; }
        public Order? Order { get; set; }
    }
}