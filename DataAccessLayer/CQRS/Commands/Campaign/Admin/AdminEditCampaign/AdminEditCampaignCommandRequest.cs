using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class AdminEditCampaignCommandRequest: IRequest<AdminEditCampaignCommandResponse>
    {
        public double CampaignId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public bool IsApproved { get; set; }
        public string? CampaignImage { get; set; }
    }
}