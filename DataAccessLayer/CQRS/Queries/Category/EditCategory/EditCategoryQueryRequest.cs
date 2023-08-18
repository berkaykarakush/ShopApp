using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditCategoryQueryRequest :IRequest<EditCategoryQueryResponse>
    {
        public double Id { get; set; }
    }
}