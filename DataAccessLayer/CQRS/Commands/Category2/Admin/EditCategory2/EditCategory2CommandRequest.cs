using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditCategory2CommandRequest: IRequest<EditCategory2CommandResponse>
    {
        public double Category2Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public double CategoryId { get; set; }
    }
}