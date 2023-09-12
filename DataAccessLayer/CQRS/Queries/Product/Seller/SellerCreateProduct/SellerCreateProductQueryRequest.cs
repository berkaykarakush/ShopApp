using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerCreateProductQueryRequest: IRequest<SellerCreateProductQueryResponse>
    {
    }
}