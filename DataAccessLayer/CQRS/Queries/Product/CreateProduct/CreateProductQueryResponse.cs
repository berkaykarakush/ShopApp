using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class CreateProductQueryResponse
    {
        public bool IsSuccess { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Brand>? Brands { get; set; }
    }
}