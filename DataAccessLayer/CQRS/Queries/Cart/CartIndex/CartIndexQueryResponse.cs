﻿using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class CartIndexQueryResponse
    {
        public bool IsSuccess { get; set; }     
        public double CartId { get; set; }
        public decimal TotalPrice { get; set; }
        public Product? ProductModel { get; set; } 
        public List<CartItem>? CartItems { get; set; } = new List<CartItem>();
    }
}