using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditCategory2QueryRequest: IRequest<EditCategory2QueryResponse>
    {
        public double Category2Id { get; set; }
    }
}