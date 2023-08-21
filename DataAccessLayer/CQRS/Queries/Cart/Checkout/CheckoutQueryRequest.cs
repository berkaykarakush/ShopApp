using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class CheckoutQueryRequest: IRequest<CheckoutQueryResponse>
    {
        public Cart? Cart{ get; set; }
    }
}