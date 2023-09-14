using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerListOrderQueryRequest: IRequest<SellerListOrderQueryResponse>
    {
        public string UserId { get; set; }
    }
}