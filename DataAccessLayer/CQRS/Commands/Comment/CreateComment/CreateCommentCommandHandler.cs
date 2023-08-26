using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommandRequest, CreateCommentCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCommentCommandResponse> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _unitOfWork.Products.GetById(request.ProductId);
                _unitOfWork.Comments.Create(new Comment()
                {
                    CommentId = request.CommentId,
                    CreatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    Description = request.Description,
                    UserId = request.UserId,
                    UserFirstname = request.UserFirstname,
                    UserLastname = request.UserLastname,
                    ProductId = request.ProductId,
                    Product = product,
                });
                _unitOfWork.Save();
                return await Task.FromResult(new CreateCommentCommandResponse() { IsSuccess = true, Url= product.Url});
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return await Task.FromResult(new CreateCommentCommandResponse() { IsSuccess = false });
        }
    }
}
