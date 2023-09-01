namespace PresentationLayer.Models
{
    public class ProductCategoryVM
    {
        public double Id { get; set; }
        public double CategoryId { get; set; }
        public CategoryVM? Category { get; set; }
        public double ProductId { get; set; }
        public ProductVM? Product { get; set; }
    }
}
