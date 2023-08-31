namespace EntityLayer
{
    public class Category2
    {
        public Category2()
        {
            Category2Id = new Random().Next(111111111, 999999999);
        }
        public double Category2Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }

        public double? CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<Product>? Products { get; set; }

    }
}
