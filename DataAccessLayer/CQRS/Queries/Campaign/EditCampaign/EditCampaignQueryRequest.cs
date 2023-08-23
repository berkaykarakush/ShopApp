using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditCampaignQueryRequest: IRequest<EditCampaignQueryResponse>
    {
        public double CampaignId { get; set; }
    }
}