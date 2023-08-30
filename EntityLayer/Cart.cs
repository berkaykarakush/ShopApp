namespace EntityLayer
{
    public class Cart 
    {
        public Cart()
        {
            CartId = new Random().Next(111111111, 999999999);
        }
        public double CartId { get; set; }
        public string? UserId { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public List<CartItem>? CartItems { get; set; }
    }
}
