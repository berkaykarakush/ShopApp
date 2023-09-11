using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminListOrderQueryResponse
    {
        public bool IsSuccess { get; set; }
        public List<Order>? Orders { get; set; }
    }
}