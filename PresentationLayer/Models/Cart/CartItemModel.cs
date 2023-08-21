namespace PresentationLayer.Models
{
    public class CartItemModel
    {
        public double CartItemId { get; set; }
        public int Stock { get; set; }
        public double ProductId { get; set; }
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public string? ProductImage { get; set; }
        public int Quantity { get; set; }
    }
}
