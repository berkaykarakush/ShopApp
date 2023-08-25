using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListBrandQueryResponse
    {
        public List<Brand> Brands { get; set; }
        public bool IsSuccess { get; set; }
    }
}