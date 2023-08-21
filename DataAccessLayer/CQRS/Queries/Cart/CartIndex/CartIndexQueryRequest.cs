using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class CartIndexQueryRequest:IRequest<CartIndexQueryResponse>
    {
        public Cart? Cart { get; set; }
    }
}