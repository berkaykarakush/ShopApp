using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerRegisterCommandRequest: IRequest<SellerRegisterCommandResponse>
    {
        public string? StoreName { get; set; }
        public string? SellerId { get; set; }
        public string? SellerFirstName { get; set; }
        public string? SellerLastName { get; set; }
        public string? SellerEmail { get; set; }
        public string? SellerPhone { get; set; }
    }
}