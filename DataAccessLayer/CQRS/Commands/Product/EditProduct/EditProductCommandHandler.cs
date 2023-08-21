using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommandRequest, EditProductCommandResponse>
    {
        readonly IUnitOfWork _unitOfWork;

        public EditProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EditProductCommandResponse> Handle(EditProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = _unitOfWork.Products.GetById(request.ProductId);
                product.Name = request.Name;
                product.Url = request.Url;
                product.Price = request.Price;
                product.Quantity = request.Quantity;
                product.Description = request.Description;
                product.ImageUrls = request.ImageUrls;
                product.ProductImage = request.ProductImage;
                product.IsApproved = request.IsApproved;
                product.IsHome = request.IsHome;
                product.UpdatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                product.ProductCategories = request.SelectedCategories;
                _unitOfWork.Products.Update(product, request.CategoryIds);
                _unitOfWork.Save();

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return new EditProductCommandResponse() { IsSuccess = false };
            }
            return new EditProductCommandResponse() 
            { 
                ProductId = request.ProductId,
                IsSuccess = true
            };            
        }
    }
}
