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
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? CampaignImage { get; set; }
        public List<ImageUrl>? ImageUrls { get; set; } = new List<ImageUrl>();
        public bool IsSuccess { get; set; } 
    }
}