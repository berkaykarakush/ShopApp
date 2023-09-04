using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditStoreQueryRequest: IRequest<EditStoreQueryResponse>
    {
        public double StoreId { get; set; }
    }
}