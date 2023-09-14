namespace EntityLayer
{
    public class Cart : BaseEntity
    {
        public double CartId { get; set; } = new Random().Next(111111111, 999999999);
        public string? UserId { get; set; }
        public List<CartItem>? CartItems { get; set; }
    }
}
