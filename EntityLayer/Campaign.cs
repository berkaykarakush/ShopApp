﻿namespace EntityLayer
{
    public class Campaign: BaseEntity
    {
        public double CampaignId { get; set; } = new Random().Next(111111111, 999999999);
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public int DiscountPercentage { get; set; }
        public bool IsApproved { get; set; }
        public string? CampaignImage { get; set; }
    }
}
