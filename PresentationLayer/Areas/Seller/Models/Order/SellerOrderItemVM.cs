using PresentationLayer.Areas.Admin.Models;
using PresentationLayer.Models;

namespace PresentationLayer.Areas.Seller.Models 
{
    public class SellerOrderItemVM
    {
        public double OrderItemId { get; set; }
        public double OrderId { get; set; }
        public SellerOrderVM? Order { get; set; }
        public double ProductId { get; set; }
        public ProductVM? Product { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Quantity { get; set; }
        public string? Name { get; set; }
        public string? ProductImage { get; set; }
    }
}
