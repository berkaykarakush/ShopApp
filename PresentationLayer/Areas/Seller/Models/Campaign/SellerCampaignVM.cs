﻿namespace PresentationLayer.Areas.Seller.Models 
{
    public class SellerCampaignVM
    {
        public double CampaignId { get; set; }  
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public bool IsApproved { get; set; }
        public string? CampaignImage { get; set; }
    }
}
