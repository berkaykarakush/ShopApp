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

        public Task<CreateCommentCommandResponse> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _unitOfWork.Products.GetById(request.ProductId);

                if (product == null)
                    return Task.FromResult(new CreateCommentCommandResponse() { IsSuccess = false });

                var comment = new Comment() 
                {
                    CreatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    Description = request.Description,
                    UserId = request.UserId,
                    UserFirstname = request.UserFirstname,
                    UserLastname = request.UserLastname,
                    ProductId = request.ProductId,
                    Product = product,
                };

                if (comment == null)
                    return Task.FromResult(new CreateCommentCommandResponse() { IsSuccess = false});

                _unitOfWork.Comments.Create(comment);
                _unitOfWork.Save();
                return Task.FromResult(new CreateCommentCommandResponse() { IsSuccess = true, Url= product.Url});
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new CreateCommentCommandResponse() { IsSuccess = false });
        }
    }
}
