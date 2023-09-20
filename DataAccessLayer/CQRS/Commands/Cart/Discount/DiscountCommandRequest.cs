using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class DiscountCommandRequest: IRequest<DiscountCommandResponse>
    {
        public string? Code { get; set; }
        public double CartId { get; set; }
    }
}