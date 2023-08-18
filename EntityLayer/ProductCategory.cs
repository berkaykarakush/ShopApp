namespace EntityLayer
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            Random random = new();
            Id = random.Next(111111111, 999999999);
        }
        public double Id { get; set; }
        public double CategoryId { get; set; }
        public Category Category { get; set; }
        public double ProductId { get; set; }
        public Product Product { get; set; }
    }
}
