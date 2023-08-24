namespace EntityLayer
{
    public class CartItem
    {
        public CartItem()
        {
            Random random = new();
            CartItemId = random.Next(111111111, 999999999);
        }
        public double CartItemId { get; set; }
        public double ProductId { get; set; }
        public Product? Product { get; set; }
        public double CartId { get; set; }
        public Cart? Cart { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
    }
}
