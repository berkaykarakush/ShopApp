using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerStoreIndexQueryRequest: IRequest<SellerStoreIndexQueryResponse>
    {
        public string UserId { get; set; } = string.Empty;
    }
}