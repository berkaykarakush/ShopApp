using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class CartModel
    {
        public int CartId { get; set; }
        public List<CartItemModel>? CartItems { get; set; }
        public decimal TotalPrice()
        {
            return (decimal)CartItems.Sum(c => c.Price * c.Quantity);
        }
    }
}
