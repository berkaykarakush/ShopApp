using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerListCampaignQueryRequest: IRequest<SellerListCampaignQueryResponse>
    {
    }
}