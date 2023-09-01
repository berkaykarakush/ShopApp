using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class CreateCommentCommandRequest: IRequest<CreateCommentCommandResponse>
    {
        public double ProductId { get; set; }
        public Product? Product { get; set; }
        public string? UserId { get; set; }
        public string? UserFirstname { get; set; }
        public string? UserLastname { get; set; }
        public string? Description { get; set; }
        public string? CreatedDate { get; set; }
    }
}