using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteProductCommandRequest: IRequest<DeleteProductCommandResponse>
    {
        public double productId { get; set; }
    }
}