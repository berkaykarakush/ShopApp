using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerEditCampaignCommandRequest: IRequest<SellerEditCampaignCommandResponse>
    {
        public double CampaignId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public int DiscountPercentage { get; set; }
        public string? CampaignImage { get; set; }
    }
}