using DataAccessLayer.Abstract;
using MediatR;
using Serilog;
using System.Runtime.InteropServices;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerDetailCommentQueryHandler : IRequestHandler<SellerDetailCommentQueryRequest, SellerDetailCommentQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerDetailCommentQueryHandler(IUnitOfWork unitOfWork)
            =>  _unitOfWork = unitOfWork;

        public Task<SellerDetailCommentQueryResponse> Handle(SellerDetailCommentQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var comment = _unitOfWork.Comments.GetById(request.CommentId);

                if (comment == null)
                    return Task.FromResult(new SellerDetailCommentQueryResponse() { IsSuccess = false});

                return Task.FromResult(new SellerDetailCommentQueryResponse() 
                { 
                    IsSuccess = true,
                    CommentId = comment.CommentId,
                    CommentRate = comment.CommentRate,
                    Description = comment.Description,
                    ProductId = comment.ProductId,
                    StoreId = comment.StoreId,
                    UserFirstname = comment.UserFirstname,
                    UserLastname = comment.UserLastname,
                    UserId = comment.UserId,
                    SellerAnswer = comment.SellerAnswer
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new SellerDetailCommentQueryResponse() { IsSuccess = false });
        }
    }
}
