namespace EntityLayer
{
    public class Brand
    {
        public Brand()
        {
            BrandId = new Random().Next(111111111,999999999);
        }
        public double BrandId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public List<Product>? Products { get; set; }
    }
}
