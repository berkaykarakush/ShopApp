using MediatR;

namespace DataAccessLayer.CQRS.Commands 
{
    public class AdminDeleteOrderCommandRequest : IRequest<AdminDeleteOrderCommandResponse>
    {
        public double OrderId { get; set; }
    }
}