namespace EntityLayer
{
    public class ImageUrl : BaseEntity
    {
        public double ImageUrlId { get; set; } = new Random().Next(111111111, 999999999);
        public string? Url { get; set; }

        //public Campaign? Campaign { get; set; }
        //public double CampaignId { get; set; }

        public double? ProductId { get; set; }
        public Product? Product { get; set; }

        public double? StoreId { get; set; }
        public Store? Store { get; set; }
    }
}
