using EntityLayer;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerDetailOrderCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string? CustomerEmail { get; set; }
        public EnumOrderState OrderState { get; set; }
    }
}