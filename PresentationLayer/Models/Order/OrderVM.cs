using EntityLayer;

namespace PresentationLayer.Models  
{
    public class OrderVM
    {
        public double OrderId { get; set; }
        public string? OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }
        public string? PaymentId { get; set; }
        public string? ConversationId { get; set; }
        public EnumPaymentType PaymentType { get; set; }
        public EnumOrderState OrderState { get; set; }
        public List<OrderItemModel>? OrderItems { get; set; }
        public decimal TotalPrice()
        {
            return OrderItems.Sum(o => o.Price * o.Quantity);
        }
    }
}
