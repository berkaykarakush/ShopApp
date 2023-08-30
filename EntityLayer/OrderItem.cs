using System.Reflection.Metadata;

namespace EntityLayer
{
    public class OrderItem
    {
        public OrderItem()
        {
            OrderItemId = new Random().Next(111111111, 999999999);
        }
        public double OrderItemId { get; set; }
        public double OrderId { get; set; }
        public Order? Order { get; set; }
        public double ProductId { get; set; }
        public Product? Product { get; set; }
        public double Price { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public int Quantity { get; set; }
    }
}
