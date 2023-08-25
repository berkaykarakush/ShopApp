using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class UpdateBrandQueryRequest: IRequest<UpdateBrandQueryResponse>
    {
        public double BrandId { get; set; }
    }
}