using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;
using System.Xml.Linq;

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
                    Description = request.Description,
                    UserId = request.UserId,
                    UserFirstname = request.UserFirstname,
                    UserLastname = request.UserLastname,
                    ProductId = request.ProductId,
                    Product = product,
                };

                if (comment == null)
                    return Task.FromResult(new CreateCommentCommandResponse() { IsSuccess = false});

                if (request.Rate1)
                    comment.CommentRate += 1;

                if (request.Rate2)
                    comment.CommentRate += 1;

                if (request.Rate3)
                    comment.CommentRate += 1;

                if (request.Rate4)
                    comment.CommentRate += 1;

                if (request.Rate5)
                    comment.CommentRate += 1;


                //**********************
                // One comment 1 point, one comment 3 point total 4 point 
                // so
                //CommentCount = 2
                //StartCount = 4
                //ProductRate =  4/2 = 2
                product.CommentCount += 1; 
                product.StarCount += comment.CommentRate; 
                product.ProductRate = (decimal)product.StarCount / (decimal)product.CommentCount;
                //**********************

                _unitOfWork.Products.Update(product);
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
