using Azure;
using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using System.Diagnostics;
using System;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditProductQueryHandler : IRequestHandler<EditProductQueryRequest, EditProductQueryResponse>
    {
        readonly IUnitOfWork _unitOfWork;

        public EditProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EditProductQueryResponse> Handle(EditProductQueryRequest request, CancellationToken cancellationToken)
        {
            Product product = new Product();
            try
            {
                product = _unitOfWork.Products.GetByIdWithCategories(request.Id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
            
            var response = new EditProductQueryResponse();
            response.ProductId = product.ProductId;
            response.Name = product.Name;
            response.Url = product.Url;
            response.Price = product.Price;
            response.Quantity = product.Quantity;
            response.Description = product.Description;
            response.ProductImage = product.ProductImage;
            response.IsApproved = product.IsApproved;
            response.IsHome = product.IsHome;
            response.Categories.AddRange(_unitOfWork.Categories.GetAll());
            response.IsSuccess = true;
            return response;
        }
    }
}
