using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListCampaignQueryResponse
    {
        public List<Campaign> Campaigns { get; set; }

        public bool IsSuccess { get; set; } = false;
    }
}