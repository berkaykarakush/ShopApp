namespace EntityLayer
{
    public class Category2: BaseEntity
    {
        public double Category2Id { get; set; } = new Random().Next(111111111, 999999999);
        public string? Name { get; set; }
        public string? Url { get; set; }

        public double? CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<Product>? Products { get; set; }

    }
}
