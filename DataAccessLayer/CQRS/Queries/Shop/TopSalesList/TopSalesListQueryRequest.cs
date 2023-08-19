using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class TopSalesListQueryRequest: IRequest<TopSalesListQueryResponse>
    {
        public TopSalesListQueryRequest()
        {
            page = 1;
        }
        public int page { get; set; }
    }
}