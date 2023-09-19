using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminListCampaignQueryRequest: IRequest<AdminListCampaignQueryResponse>
    {
    }
}