using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class CreateProductQueryResponse
    {
        public bool IsSuccess { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Category2>? Categories2 { get; set; }
        public List<Brand>? Brands { get; set; }
    }
}