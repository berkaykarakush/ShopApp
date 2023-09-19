using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerDeleteCampaignCommandRequest : IRequest<SellerDeleteCampaignCommandResponse>
    {
        public double CampaignId { get; set; }
    }
}