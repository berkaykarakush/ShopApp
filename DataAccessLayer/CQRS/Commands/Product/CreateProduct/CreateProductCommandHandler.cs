using DataAccessLayer.Abstract;
using EntityLayer;
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
        public Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var category = _unitOfWork.Categories.GetById(request.CategoryId);
                var brand = _unitOfWork.Brands.GetById(request.BrandId);

                if (category == null && brand == null)
                    return Task.FromResult(new CreateProductCommandResponse() { IsSuccess = false });


                var product = new Product()
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
                    Brand = brand,
                    BrandId = brand.BrandId
                };

                var productCategory = new ProductCategory()
                {
                    Category = category,
                    CategoryId = category.CategoryId,
                    Product = product,
                    ProductId = product.ProductId,
                    CreatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                };

                if (productCategory != null)
                    product.ProductCategories.Add(productCategory);

                _unitOfWork.Products.Create(product);
                _unitOfWork.Save();
                return Task.FromResult(new CreateProductCommandResponse() { IsSuccess = true, ProductId = request.ProductId });
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            return Task.FromResult(new CreateProductCommandResponse() { IsSuccess = false});
        }
    }
}
