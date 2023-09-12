using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerEditProductQueryRequest: IRequest<SellerEditProductQueryResponse>
    {
        public double Id { get; set; }
    }
}