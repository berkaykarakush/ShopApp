namespace EntityLayer
{
    public class Category : BaseEntity
    {
        public double CategoryId { get; set; } = new Random().Next(111111111, 999999999);
        public string? Name { get; set; }
        public string? Url { get; set; }

        public Category2? Category2 { get; set; }               
        public List<Product>? Products { get; set; }
    }
}
