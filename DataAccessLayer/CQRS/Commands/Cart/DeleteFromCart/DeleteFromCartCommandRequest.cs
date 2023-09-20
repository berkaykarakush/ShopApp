using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteFromCartCommandRequest: IRequest<DeleteFromCartCommandResponse>
    {
        public double ProductId { get; set; }
        public string? UserId { get; set; }
    }
}