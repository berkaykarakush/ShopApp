using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListCategoryQueryResponse
    {
        public bool IsSuccess { get; set; }
        public List<Category> Categories { get; set; }
    }
}