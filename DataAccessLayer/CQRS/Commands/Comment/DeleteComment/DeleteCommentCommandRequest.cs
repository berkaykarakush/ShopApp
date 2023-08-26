using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteCommentCommandRequest: IRequest<DeleteCommentCommandResponse>
    {
        public double CommentId { get; set; }
    }
}