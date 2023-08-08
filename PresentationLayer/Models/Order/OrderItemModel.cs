using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace PresentationLayer.Models
{
    public class OrderItemModel
    {
        public int OrderItemId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
    }
}
