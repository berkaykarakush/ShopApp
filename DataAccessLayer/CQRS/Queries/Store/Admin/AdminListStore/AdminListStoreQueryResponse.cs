using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminListStoreQueryResponse
    {
        public bool IsSuccess { get; set; }
        public List<Store>? Stores { get; set; }
    }
}