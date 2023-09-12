using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminEditProductQueryRequest: IRequest<AdminEditProductQueryResponse>
    {
        public double Id { get; set; }
    }
}