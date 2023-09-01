using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditCategoryQueryResponse
    {
        public double CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public List<Product>? Products { get; set; } = new List<Product>();
        public bool IsSuccess { get; set; } 
    }
}