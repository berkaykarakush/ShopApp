using Azure;
using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using System.Diagnostics;
using System;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminEditProductQueryHandler : IRequestHandler<AdminEditProductQueryRequest, AdminEditProductQueryResponse>
    {
        readonly IUnitOfWork _unitOfWork;

        public AdminEditProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AdminEditProductQueryResponse> Handle(AdminEditProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = _unitOfWork.Categories.GetAll();
                var categories2 = _unitOfWork.Categories2.GetAll();
                var brands = _unitOfWork.Brands.GetAll();
                var product = _unitOfWork.Products.GetByIdWithImageUrls(request.Id);
                
                if (product == null || categories == null || categories2 == null || brands == null)
                    return Task.FromResult(new AdminEditProductQueryResponse() { IsSuccess = false });

                return Task.FromResult(new AdminEditProductQueryResponse() 
                {
                    IsSuccess = true,
                    Brands = brands,
                    Categories = categories,
                    Categories2 = categories2,
                    Name = product.Name,
                    Description = product.Description,
                    ImageUrls = product.ImageUrls,
                    IsApproved = product.IsApproved,
                    IsHome = product.IsHome,
                    Price = product.Price,
                    ProductId = product.ProductId,
                    ProductImage = product.ProductImage,
                    Quantity = product.Quantity,
                    Url = product.Url,
                    BrandName = product.Brand.Name,
                    BrandId = product.Brand.BrandId,
                    CategoryName = product.Category.Name,
                    CategoryId = product.Category.CategoryId,
                    Category2Name = product.Category2.Name,
                    Category2Id = product.Category2.Category2Id
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new AdminEditProductQueryResponse() { IsSuccess = false });
        }
    }
}
