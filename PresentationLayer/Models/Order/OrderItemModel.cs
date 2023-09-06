using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace PresentationLayer.Models
{
    public class OrderItemModel
    {
        public double OrderItemId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
    }
}
