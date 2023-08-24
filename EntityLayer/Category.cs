namespace EntityLayer
{
    public class Category
    {
        public Category()
        {
            Random random = new();
            CategoryId = random.Next(111111111, 999999999);
            ProductCategories = new List<ProductCategory>();
            Products = new List<Product>();
        }
        public double CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public List<ProductCategory>? ProductCategories { get; set; }
        public List<Product>? Products { get; set; }

    }
}
