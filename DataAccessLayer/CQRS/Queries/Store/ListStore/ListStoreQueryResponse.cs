using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListStoreQueryResponse
    {
        public bool IsSuccess { get; set; }
        public List<Store>? Stores { get; set; }
    }
}