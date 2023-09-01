using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListCategory2QueryResponse
    {
        public List<Category2>? Categories2 { get; set; } = new List<Category2>();  
        public bool IsSuccess { get; set; }
    }
}