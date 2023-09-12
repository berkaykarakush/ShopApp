using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerListProductQueryRequest: IRequest<SellerListProductQueryResponse>
    {
        public string? SellerId { get; set; }
    }
}