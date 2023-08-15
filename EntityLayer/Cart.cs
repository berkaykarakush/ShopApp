namespace EntityLayer
{
    public class Cart
    {
        public Cart()
        {
            Random random = new();
            CartId = random.NextDouble();
        }
        public double CartId { get; set; }
        public string UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
