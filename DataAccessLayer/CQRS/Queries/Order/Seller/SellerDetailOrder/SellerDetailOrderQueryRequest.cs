using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerDetailOrderQueryRequest: IRequest<SellerDetailOrderQueryResponse>
    {
        public double Id { get; set; }
    }   
}