using DataAccessLayer.Abstract;
using DataAccessLayer.Configurations;
using EntityLayer;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerCreateProductCommandHandler : IRequestHandler<SellerCreateProductCommandRequest, SellerCreateProductCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerCreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<SellerCreateProductCommandResponse> Handle(SellerCreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var store = _unitOfWork.Stores.GetStore(request.SellerId ?? string.Empty);
                var brand = _unitOfWork.Brands.GetById(request.BrandId);
                var category = _unitOfWork.Categories.GetById(request.CategoryId);
                var category2 = _unitOfWork.Categories2.GetById(request.Category2Id);

                if (store == null || brand == null || category == null || category2 == null)
                    return Task.FromResult(new SellerCreateProductCommandResponse() { IsSuccess = false });

                var product = new Product()
                {
                    Name = request.Name,
                    Url = request.Url,
                    Price = request.Price,
                    Quantity = request.Quantity,
                    Description = request.Description,
                    ProductImage = request.ProductImage,
                    CreatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    BrandId = request.BrandId,
                    Brand = brand,
                    CategoryId = request.CategoryId,
                    Category = category,
                    Category2Id = request.Category2Id,
                    Category2 = category2,
                    StoreId = store.StoreId,
                    Store = store,
                    ImageUrls = request.ImageUrls
                };


                _unitOfWork.Products.Create(product);
                _unitOfWork.Save();
                return Task.FromResult(new SellerCreateProductCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new SellerCreateProductCommandResponse() { IsSuccess = false});
        }
    }
}
