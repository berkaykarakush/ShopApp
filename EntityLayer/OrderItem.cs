using System.Reflection.Metadata;

namespace EntityLayer
{
    public class OrderItem : BaseEntity
    {
        public double OrderItemId { get; set; } = new Random().Next(111111111, 999999999);
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Name { get; set; }
        public string? ProductImage { get; set; }

        public double? OrderId { get; set; }
        public Order? Order { get; set; }

        public double? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
