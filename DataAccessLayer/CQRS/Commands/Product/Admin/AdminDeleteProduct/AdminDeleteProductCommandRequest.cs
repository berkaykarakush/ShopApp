using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class AdminDeleteProductCommandRequest : IRequest<AdminDeleteProductCommandResponse>
    {
        public double productId { get; set; }
    }
}