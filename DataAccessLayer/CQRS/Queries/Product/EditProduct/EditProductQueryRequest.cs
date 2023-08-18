using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditProductQueryRequest: IRequest<EditProductQueryResponse>
    {
        public double Id { get; set; }
    }
}