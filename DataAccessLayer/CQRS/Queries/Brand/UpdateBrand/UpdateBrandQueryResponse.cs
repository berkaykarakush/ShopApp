using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class UpdateBrandQueryResponse
    {
        public Brand? Brand { get; set; }
        public bool IsSuccess { get; set; }
    }
}