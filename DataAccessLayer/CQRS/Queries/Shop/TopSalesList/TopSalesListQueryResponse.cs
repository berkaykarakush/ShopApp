﻿using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class TopSalesListQueryResponse
    {
        public PageInfo? PageInfo { get; set; }
        public List<Product>? Products { get; set; } = new List<Product>();
        public bool IsSuccess { get; set; }     
    }
}