namespace EntityLayer
{
    public class Campaign
    {
        public Campaign()
        {
            Random random = new();
            CampaignId = random.Next(111111111, 999999999);
        }
        public double CampaignId { get; set; }
        public string? Name { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public bool IsHome { get; set; }
        public string? CampaignImage { get; set; }
        public List<ImageUrl>? ImageUrls { get; set; }
    }
}
