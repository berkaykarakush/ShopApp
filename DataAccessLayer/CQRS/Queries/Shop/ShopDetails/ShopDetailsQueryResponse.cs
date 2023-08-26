﻿using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopDetailsQueryResponse
    {
        public Product Product { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public List<Category> Categories { get; set; }
        public bool IsSuccess { get; set; } = false;
    }
}