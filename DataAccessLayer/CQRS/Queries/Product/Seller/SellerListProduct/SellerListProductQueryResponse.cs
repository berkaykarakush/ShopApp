using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerListProductQueryResponse
    {
        public List<Product>? Products { get; set; }
        public bool IsSucces { get; set; }
    }
}