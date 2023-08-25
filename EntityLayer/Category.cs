namespace EntityLayer
{
    public class Category 
    {
        public Category()
        {
            Random random = new();
            CategoryId = random.Next(111111111, 999999999);
        }
        public double CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public List<ProductCategory>? ProductCategories { get; set; }
        public List<Product>? Products { get; set; }

    }
}
