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
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Code { get; set; }
    }
}
