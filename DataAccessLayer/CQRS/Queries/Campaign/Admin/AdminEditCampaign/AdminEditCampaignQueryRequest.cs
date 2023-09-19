using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminEditCampaignQueryRequest: IRequest<AdminEditCampaignQueryResponse>
    {
        public double CampaignId { get; set; }
    }
}