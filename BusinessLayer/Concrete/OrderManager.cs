using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Create(Order entity)
        {
            //TODO is kurallari
            _unitOfWork.Orders.Create(entity);
            _unitOfWork.Save();
        }

        public void Delete(Order entity)
        {
            //TODO is kurallari
            _unitOfWork.Orders.Delete(entity);
            _unitOfWork.Save();
        }

        public List<Order> GetAll()
        {
           return _unitOfWork.Orders.GetAll();
        }

        public Order GetById(int id)
        {
            //TODO is kurallari
            return _unitOfWork.Orders.GetById(id);
        }

        public List<Order> GetOrders(string userId)
        {
            return _unitOfWork.Orders.GetOrders(userId);
        }

        public void Update(Order entity)
        {
            //TODO is kurallari
            _unitOfWork.Orders.Update(entity);
            _unitOfWork.Save();
        }

        public bool Validation(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
