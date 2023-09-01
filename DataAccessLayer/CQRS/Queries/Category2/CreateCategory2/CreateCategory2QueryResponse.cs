using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class CreateCategory2QueryResponse
    {
        public bool IsSuccess { get; set; }
        public List<Category>? Categories { get; set; } = new List<Category>();
    }
}