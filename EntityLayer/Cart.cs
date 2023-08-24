namespace EntityLayer
{
    public class Cart
    {
        public Cart()
        {
            Random random = new();
            CartId = random.Next(111111111,999999999);
            CartItems = new List<CartItem>();
        }
        public double CartId { get; set; }
        public string? UserId { get; set; }
        public List<CartItem>? CartItems { get; set; }
    }
}
