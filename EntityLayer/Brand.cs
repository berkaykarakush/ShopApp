namespace EntityLayer
{
    public class Brand: BaseEntity
    {
        public double BrandId { get; set; } = new Random().Next(111111111, 999999999);
        public string? Name { get; set; }
        public string? Url { get; set; }
        public List<Product>? Products { get; set; } 
    }
}
