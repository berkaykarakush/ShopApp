using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string ErrorMessage { get; set; }
        public List<Order> GetAll()
        {
           return _unitOfWork.Orders.GetAll();
        }

        public Order GetById(int id)
        {
            return _unitOfWork.Orders.GetById(id);
        }

        public List<Order> GetOrders(string userId)
        {
            return _unitOfWork.Orders.GetOrders(userId);
        }
        public bool Create(Order entity)
        {
            if(Validation(entity))
            {
               _unitOfWork.Orders.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            ErrorMessage += "Order not created.\n";
            return false;
        }
        public bool Delete(Order entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.Orders.Delete(entity);
                _unitOfWork.Save();
                return true;
            }
            ErrorMessage += "Order not deleted.\n";
            return false;
        }
        public bool Update(Order entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.Orders.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            ErrorMessage += "Order not updated.\n";
            return false;

        }

        public bool Validation(Order entity)
        {
            //TODO order validation
            bool isValid = true;
            if (string.IsNullOrEmpty(entity.FirstName))
            {
                ErrorMessage += $"FirstName is reqiured.\n";
                return false;
            }
            if (string.IsNullOrEmpty(entity.LastName))
            {
                ErrorMessage += $"LastName is reqiured.\n";
                return false;
            }
            if (string.IsNullOrEmpty(entity.Address))
            {
                ErrorMessage += $"Address is reqiured.\n";
                return false;
            } 
            if (string.IsNullOrEmpty(entity.City))
            {
                ErrorMessage += $"City is reqiured.\n";
                return false;
            }
            if (string.IsNullOrEmpty(entity.Phone))
            {
                ErrorMessage += $"Phone is reqiured.\n";
                return false;
            }
            if (string.IsNullOrEmpty(entity.Email))
            {
                ErrorMessage += $"Email is reqiured.\n";
                return false;
            }
            return isValid;
        }
    }
}
