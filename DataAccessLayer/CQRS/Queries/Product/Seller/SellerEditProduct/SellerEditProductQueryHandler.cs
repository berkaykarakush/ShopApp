using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerEditProductQueryHandler : IRequestHandler<SellerEditProductQueryRequest, SellerEditProductQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerEditProductQueryHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public Task<SellerEditProductQueryResponse> Handle(SellerEditProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _unitOfWork.Products.GetByIdWithImageUrls(request.Id);
                var brands = _unitOfWork.Brands.GetAll();
                var categories = _unitOfWork.Categories.GetAll();
                var categories2 = _unitOfWork.Categories2.GetAll();

                if (product == null || brands == null || categories == null || categories2 == null)
                    return Task.FromResult(new SellerEditProductQueryResponse() { IsSuccess = false });

                return Task.FromResult(new SellerEditProductQueryResponse() 
                { 
                    IsSuccess = true,
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Url = product.Url,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Description = product.Description,
                    ProductImage = product.ProductImage,
                    BrandId = product.BrandId,
                    CategoryId = product.CategoryId,
                    Category2Id = product.Category2Id,
                    StoreId = product.StoreId,
                    ImageUrls = product.ImageUrls,
                    Comments = product.Comments,
                    Brands = brands,
                    Categories = categories,
                    Categories2 = categories2,
                    BrandName = product.Brand.Name,
                    CategoryName = product.Category.Name,
                    Category2Name = product.Category2.Name
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new SellerEditProductQueryResponse() { IsSuccess = false });
        }
    }
}
