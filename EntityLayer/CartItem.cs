namespace EntityLayer
{
    public class CartItem
    {
        public double CartItemId { get; set; } = new Random().Next(111111111, 999999999);
        public double ProductId { get; set; }
        public Product? Product { get; set; }
        public double CartId { get; set; }
        public Cart? Cart { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
    }
}
