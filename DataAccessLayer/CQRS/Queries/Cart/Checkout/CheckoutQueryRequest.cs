using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class CheckoutQueryRequest: IRequest<CheckoutQueryResponse>
    {
        public string? UserId { get; set; }
    }
}