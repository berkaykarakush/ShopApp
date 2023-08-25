namespace EntityLayer
{
    public class ImageUrl 
    {
        public ImageUrl()
        {
            Random random = new();
            ImageUrlId = random.Next(111111111, 999999999);
        }
        public double ImageUrlId { get; set; }
        public double ProductId { get; set; }
        public Product? Product { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public Campaign? Campaign { get; set; }
        public double CampaignId { get; set; }
        public string? Url { get; set; }
    }
}
