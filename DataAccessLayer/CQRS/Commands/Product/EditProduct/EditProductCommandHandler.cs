using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommandRequest, EditProductCommandResponse>
    {
        readonly IUnitOfWork _unitOfWork;

        public EditProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  Task<EditProductCommandResponse> Handle(EditProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _unitOfWork.Products.GetByIdWithImageUrls(request.ProductId);
                var category = _unitOfWork.Categories.GetById(request.CategoryId);
                var category2 = _unitOfWork.Categories2.GetById(request.Category2Id);
                var brand = _unitOfWork.Brands.GetById(request.BrandId);
                if (product == null || category == null || category2 == null)
                    return Task.FromResult(new EditProductCommandResponse() { IsSuccess = false });

                product.Name = request.Name;
                product.Url = request.Url;
                product.Price = request.Price;
                product.Quantity = request.Quantity;
                product.Description = request.Description;

                if (request.ImageUrls != null)
                    product.ImageUrls = request.ImageUrls;

                if (request.ProductImage != null)
                    product.ProductImage = request.ProductImage;

                product.IsApproved = request.IsApproved;
                product.IsHome = request.IsHome;
                product.UpdatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                product.Category = category;
                product.CategoryId = category.CategoryId;

                product.Category2 = category2;
                product.Category2Id = category2.Category2Id;

                product.Brand = brand;
                product.BrandId = brand.BrandId;

                _unitOfWork.Products.Update(product);
                _unitOfWork.Save();
                return Task.FromResult(new EditProductCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            return Task.FromResult(new EditProductCommandResponse() { IsSuccess = false });
        }
    }
}
