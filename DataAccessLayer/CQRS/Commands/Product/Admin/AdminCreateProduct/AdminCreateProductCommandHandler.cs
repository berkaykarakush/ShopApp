﻿using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class AdminCreateProductCommandHandler : IRequestHandler<AdminCreateProductCommandRequest, AdminCreateProductCommandResponse>
    {
        readonly IUnitOfWork _unitOfWork;
        public AdminCreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<AdminCreateProductCommandResponse> Handle(AdminCreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var category = _unitOfWork.Categories.GetById(request.CategoryId);
                var category2 = _unitOfWork.Categories2.GetById(request.Category2Id);
                var brand = _unitOfWork.Brands.GetById(request.BrandId);

                if (category == null || category2 == null || brand == null)
                    return Task.FromResult(new AdminCreateProductCommandResponse() { IsSuccess = false });

                var product = new Product()
                {
                    Name = request.Name,
                    Url = request.Url,
                    ProductImage = request.ProductImage,
                    ImageUrls = request.ImageUrls,
                    Quantity = request.Quantity,
                    Description = request.Description,
                    IsApproved = request.IsApproved,
                    IsHome = request.IsHome,
                    Price = request.Price,
                    SalesCount = request.SalesCount,
                    Brand = brand,
                    BrandId = brand.BrandId,
                    Category = category,
                    CategoryId = category.CategoryId,
                    Category2 = category2,
                    Category2Id = category2.Category2Id
                };

                if (product == null)
                    return Task.FromResult(new AdminCreateProductCommandResponse() { IsSuccess = false });

                _unitOfWork.Products.Create(product);
                _unitOfWork.Save();
                return Task.FromResult(new AdminCreateProductCommandResponse() { IsSuccess = true, ProductId = product.ProductId });
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            return Task.FromResult(new AdminCreateProductCommandResponse() { IsSuccess = false });
        }
    }
}
