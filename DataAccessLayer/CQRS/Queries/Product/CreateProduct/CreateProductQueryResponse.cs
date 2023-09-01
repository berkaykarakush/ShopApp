using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class CreateProductQueryResponse
    {
        public bool IsSuccess { get; set; }
        public List<Category>? Categories { get; set; } = new List<Category>();
        public List<Category2>? Categories2 { get; set; } = new List<Category2>();
        public List<Brand>? Brands { get; set; } = new List<Brand>();
    }
}