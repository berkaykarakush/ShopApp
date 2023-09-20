using EntityLayer;

namespace PresentationLayer.Areas.Seller.Models
{
    public class SellerEditCampaignVM
    {
        public double CampaignId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public int DiscountPercentage { get; set; }
        public string? CampaignImage { get; set; }
        public bool IsApproved { get; set; }
    }
}
