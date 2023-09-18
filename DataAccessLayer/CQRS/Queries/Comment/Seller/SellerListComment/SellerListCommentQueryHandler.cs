using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerListCommentQueryHandler : IRequestHandler<SellerListCommentQueryRequest, SellerListCommentQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerListCommentQueryHandler(IUnitOfWork unitOfWork)
            =>  _unitOfWork = unitOfWork;

        public Task<SellerListCommentQueryResponse> Handle(SellerListCommentQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var store = _unitOfWork.Stores.GetStore(request.UserId);

                if (store == null)
                    return Task.FromResult(new SellerListCommentQueryResponse() { IsSuccess = false });

                var comments = _unitOfWork.Comments.GetAllCommentByStore(store.StoreId);

                if (comments == null)
                    return Task.FromResult(new SellerListCommentQueryResponse() { IsSuccess = false });

                return Task.FromResult(new SellerListCommentQueryResponse() { IsSuccess = true, Comments = comments });

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new SellerListCommentQueryResponse() {  IsSuccess = false});  
        }
    }
}
