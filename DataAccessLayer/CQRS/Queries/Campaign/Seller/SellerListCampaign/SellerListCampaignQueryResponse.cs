using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerListCampaignQueryResponse
    {
        public bool IsSuccess { get; set; }
        public List<Campaign>? Campaigns { get; set; }
    }
}