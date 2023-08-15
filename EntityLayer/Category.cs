namespace EntityLayer
{
    public class Category
    {
        public Category()
        {
            Random random = new();
            CategoryId = random.NextDouble();
        }
        public double CategoryId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
