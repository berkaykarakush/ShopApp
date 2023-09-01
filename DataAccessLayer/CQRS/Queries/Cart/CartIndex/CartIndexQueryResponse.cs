using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class CartIndexQueryResponse
    {
        public bool IsSuccess { get; set; }     
        public double CartId { get; set; }
        public Product? ProductModel { get; set; } 
        public List<CartItem>? CartItems { get; set; } = new List<CartItem>();
        public decimal TotalPrice()
        {
            if (CartItems != null)
                return (decimal)CartItems.Sum(c => c.Product.Price * c.Quantity);
            else
                throw new Exception("Error");
        }
    }
}