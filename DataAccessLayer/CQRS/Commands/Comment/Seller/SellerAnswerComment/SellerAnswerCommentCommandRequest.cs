using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerAnswerCommentCommandRequest: IRequest<SellerAnswerCommentCommandResponse>
    {
        public double CommentId { get; set; }
        public string? SellerAnswer { get; set; }
    }
}