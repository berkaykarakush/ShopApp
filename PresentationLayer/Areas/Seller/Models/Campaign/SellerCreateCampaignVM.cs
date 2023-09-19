using EntityLayer;

namespace PresentationLayer.Areas.Seller.Models 
{
    public class SellerCreateCampaignVM
    {
        public double CampaignId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public string? CampaignImage { get; set; }
    }
}
