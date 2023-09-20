using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class CartIndexQueryRequest:IRequest<CartIndexQueryResponse>
    {
        public string? UserId { get; set; }
        public Cart? Cart { get; set; }
    }
}