﻿using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using System;
using System.Net.Http.Headers;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopDetailsQueryHandler : IRequestHandler<ShopDetailsQueryRequest, ShopDetailsQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopDetailsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShopDetailsQueryResponse> Handle(ShopDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            Product product = new Product();
            try
            {
                product = _unitOfWork.Products.GetProductDetails(request.Url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ShopDetailsQueryResponse() { IsSuccess = false };
            }

            return new ShopDetailsQueryResponse()
            {
                Product = product,
                Categories = product.ProductCategories.Select(c => c.Category).ToList(),
                IsSuccess = true
            };
        }
    }
}
