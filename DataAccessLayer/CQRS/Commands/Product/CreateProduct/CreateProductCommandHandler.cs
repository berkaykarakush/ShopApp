using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IUnitOfWork _unitOfWork;
        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _unitOfWork.Products.Create(new EntityLayer.Product()
                {
                    ProductId = request.ProductId,
                    Name = request.Name,
                    Url = request.Url,
                    ProductImage = request.ProductImage,
                    ImageUrls = request.ImageUrls,
                    Quantity = request.Quantity,
                    CreatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    Description = request.Description,
                    IsApproved = request.IsApproved,
                    IsHome = request.IsHome,
                    Price = request.Price,
                    SalesCount = request.SalesCount,
                });

                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            return new() { IsSuccess = true, ProductId = request.ProductId};
        }
    }
}
