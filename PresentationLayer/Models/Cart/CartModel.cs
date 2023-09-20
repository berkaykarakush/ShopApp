using EntityLayer;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class CartVM
    {
        public double CartId { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Code { get; set; }
        public ProductModel? ProductModel { get; set; }
        public List<CartItemModel>? CartItems { get; set; }
    }
}
