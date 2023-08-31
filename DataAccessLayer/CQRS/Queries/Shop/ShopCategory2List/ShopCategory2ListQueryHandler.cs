﻿using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopCategory2ListQueryHandler : IRequestHandler<ShopCategory2ListQueryRequest, ShopCategory2ListQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopCategory2ListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ShopCategory2ListQueryResponse> Handle(ShopCategory2ListQueryRequest request, CancellationToken cancellationToken)
        {
            const int pageSize = 15;
            try
            {

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new ShopCategory2ListQueryResponse() { IsSuccess = false });
        }
    }
}
