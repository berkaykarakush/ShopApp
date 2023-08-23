using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditCampaignQueryResponse
    {
        public double CampaignId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public bool IsHome { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CampaignImage { get; set; }
        public List<ImageUrl>? ImageUrls { get; set; }
        public bool IsSuccess { get; set; } = false;    
    }
}