using PresentationLayer.Models;

namespace PresentationLayer.Areas.Admin.Models  
{
    public class AdminOrderItemVM
    {
        public double OrderItemId { get; set; }     
        public double OrderId { get; set; }
        public AdminOrderVM? Order { get; set; }
        public double ProductId { get; set; }
        public ProductVM? Product { get; set; }
        public decimal Price { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public int Quantity { get; set; }
        public string? Name { get; set; }
        public string? ProductImage { get; set; }
    }
}
