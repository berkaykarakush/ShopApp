﻿using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ICartService:IValidator<Cart>
    {
        void InitilazeCart(string userId);
        Cart GetCartByUserId(string userId);
        void AddToCart(string userId, int productId, int quantity);
        void DeleteFromCart(string userId, int productId);
    }
}
