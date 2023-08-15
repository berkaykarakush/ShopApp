namespace PresentationLayer.Models
{
    public class CartItemModel
    {
        public double CartItemId { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductId { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
        public int Quantity { get; set; }
    }
}
