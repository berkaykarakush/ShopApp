using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditCommentCommandRequest:IRequest<EditCommentCommandResponse>
    {
        public double CommentId { get; set; }
        public double ProductId { get; set; }
        public Product? Product { get; set; }
        public string? Description { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
    }
}