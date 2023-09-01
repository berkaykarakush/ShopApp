using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListBrandQueryResponse
    {
        public List<Brand>? Brands { get; set; } = new List<Brand>();
        public bool IsSuccess { get; set; }
    }
}