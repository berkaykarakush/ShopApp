using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class AdminDeleteCampaignCommandRequest: IRequest<AdminDeleteCampaignCommandResponse>
    {
        public double CampaignId { get; set; }
    }
}