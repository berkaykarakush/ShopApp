using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListCampaignQueryRequest: IRequest<ListCampaignQueryResponse>
    {
    }
}