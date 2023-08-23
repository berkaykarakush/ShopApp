using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteCampaignCommandRequest: IRequest<DeleteCampaignCommandResponse>
    {
        public double CampaignId { get; set; }
    }
}