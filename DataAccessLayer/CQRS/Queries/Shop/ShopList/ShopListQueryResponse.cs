﻿using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopListQueryResponse
    {
        public ShopListQueryResponse()
        {
            Products = new List<Product>();
        }
        public PageInfo? PageInfo { get; set; }
        public List<Product> Products { get; set; }
        public bool IsSuccess { get; set; }
    }
}