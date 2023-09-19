using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerEditCampaignQueryRequest: IRequest<SellerEditCampaignQueryResponse>
    {
        public double CampaignId { get; set; }
    }
}