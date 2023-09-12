using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerDeleteProductCommandRequest: IRequest<SellerDeleteProductCommandResponse>
    {
        public double ProductId { get; set; }
    }
}