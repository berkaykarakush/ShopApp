using EntityLayer;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class CartModel
    {
        public CartModel()
        {
            CartItems = new List<CartItemModel>();
            ProductModel = new ProductModel();
        }
        public double CartId { get; set; }
        public ProductModel ProductModel { get; set; }
        public List<CartItemModel> CartItems { get; set; }
        public decimal TotalPrice()
        {
            if (CartItems != null)
                return (decimal)CartItems.Sum(c => c.Price * c.Quantity);
            else
                throw new Exception("Error");
        }
    }
}
