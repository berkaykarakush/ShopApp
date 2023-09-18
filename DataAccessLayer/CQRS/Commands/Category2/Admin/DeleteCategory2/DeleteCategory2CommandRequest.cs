using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteCategory2CommandRequest : IRequest<DeleteCategory2CommandResponse>
    {
        public double Category2Id { get; set; }
    }
}