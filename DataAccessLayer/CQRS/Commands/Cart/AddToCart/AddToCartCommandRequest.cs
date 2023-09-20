using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class AddToCartCommandRequest: IRequest<AddToCartCommandResponse>
    {
        public string? UserId { get; set; }
        public double ProductId { get; set; }
        public int Quantity { get; set; }
    }
}