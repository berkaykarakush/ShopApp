using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminEditStoreQueryRequest : IRequest<AdminEditStoreQueryResponse>
    {
        public double StoreId { get; set; }
    }
}