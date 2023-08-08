﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Create(Order entity)
        {
            //TODO is kurallari
            _orderRepository.Create(entity);
        }

        public void Delete(Order entity)
        {
            //TODO is kurallari
            _orderRepository.Delete(entity);
        }

        public List<Order> GetAll()
        {
           return _orderRepository.GetAll();
        }

        public Order GetById(int id)
        {
            //TODO is kurallari
            return _orderRepository.GetById(id);
        }

        public List<Order> GetOrders(string userId)
        {
            return _orderRepository.GetOrders(userId);
        }

        public void Update(Order entity)
        {
            //TODO is kurallari
            _orderRepository.Update(entity);
        }

        public bool Validation(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
