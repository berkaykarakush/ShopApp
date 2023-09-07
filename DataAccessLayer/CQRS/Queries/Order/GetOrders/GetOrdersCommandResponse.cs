using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class GetOrdersCommandResponse
    {
        public List<Order>? Orders { get; set; }
        public bool IsSuccess { get; set; }
    }
}