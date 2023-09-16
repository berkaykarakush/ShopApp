using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerDetailOrderCommandRequest: IRequest<SellerDetailOrderCommandResponse>
    {
        public double Id { get; set; }
        public EnumOrderState OrderState { get; set; }
    }
}