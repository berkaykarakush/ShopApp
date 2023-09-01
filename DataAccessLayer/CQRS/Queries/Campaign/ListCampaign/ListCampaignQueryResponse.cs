using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListCampaignQueryResponse
    {
        public List<Campaign>? Campaigns { get; set; } = new List<Campaign>();

        public bool IsSuccess { get; set; }     
    }
}