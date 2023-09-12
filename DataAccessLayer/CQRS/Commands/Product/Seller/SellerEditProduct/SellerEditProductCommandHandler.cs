using DataAccessLayer.Abstract;
using MediatR;
using Serilog;
using System.Runtime.CompilerServices;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerEditProductCommandHandler : IRequestHandler<SellerEditProductCommandRequest, SellerEditProductCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerEditProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<SellerEditProductCommandResponse> Handle(SellerEditProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _unitOfWork.Products.GetByIdWithCategories(request.ProductId);
                var store = _unitOfWork.Stores.GetStore(request.UserId ?? string.Empty);
                var brand = _unitOfWork.Brands.GetById(request.BrandId);
                var category = _unitOfWork.Categories.GetById(request.CategoryId);
                var category2 = _unitOfWork.Categories2.GetById(request.Category2Id);

                if (product == null || store == null || brand == null || category == null || category2 == null)
                    return Task.FromResult(new SellerEditProductCommandResponse() { IsSuccess = false });

                product.Name = request.Name;
                product.Url = request.Url;
                product.Price = request.Price;
                product.Quantity = request.Quantity;
                product.Description = request.Description;

                if (request.ImageUrls != null)
                    product.ImageUrls = request.ImageUrls;

                if (request.ProductImage != null)
                    product.ProductImage = request.ProductImage;

                product.UpdatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                product.Category = category;
                product.CategoryId = category.CategoryId;

                product.Category2 = category2;
                product.Category2Id = category2.Category2Id;

                product.Brand = brand;
                product.BrandId = brand.BrandId;

                product.Store = store;
                product.StoreId = store.StoreId;

                _unitOfWork.Products.Update(product);
                _unitOfWork.Save();
                return Task.FromResult(new SellerEditProductCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new SellerEditProductCommandResponse() { IsSuccess = false});
        }
    }
}
