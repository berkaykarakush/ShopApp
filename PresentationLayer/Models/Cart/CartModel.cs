using EntityLayer;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class CartModel
    {
        public double CartId { get; set; }
        public ProductModel? ProductModel { get; set; }
        public List<CartItemModel>? CartItems { get; set; }
        public decimal TotalPrice()
        {
            if (CartItems != null)
                return CartItems.Sum(c => c.Price * c.Quantity);
            else
                throw new Exception("Error");
        }
    }
}
