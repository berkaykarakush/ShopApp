namespace EntityLayer
{
    public class CartItem
    {
        public double CartItemId { get; set; }
        public double ProductId { get; set; }
        public Product? Product { get; set; }
        public double CartId { get; set; }
        public Cart? Cart { get; set; }
        public int Quantity { get; set; }
    }
}
