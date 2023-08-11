﻿using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.EFCore;
using EntityLayer;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Identity;
using PresentationLayer.Models;
using System.Data;

namespace PresentationLayer.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private UserManager<User> _userManager;

        public CartController(ICartService cartService, UserManager<User> userManager, IOrderService orderService)
        {
            _cartService = cartService;
            _userManager = userManager;
            _orderService = orderService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            return View(new CartModel()
            {
                CartId = cart.CartId,
                CartItems = cart.CartItems.Select(c => new CartItemModel()
                {
                    ProductId = c.ProductId,
                    CartItemId = c.ProductId,
                    Name = c.Product.Name,
                    Price = (double)c.Product.Price,
                    Quantity = c.Quantity,
                    ImageUrl = c.Product.ImageUrl
                }).ToList()
            });
        }

        //TODO urunun miktarini kontrol et ve sepete ekle
        //TODO details view icerisinde stok durumu var ise sepete ekle secenegini cikart
        [Authorize]
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var userId = _userManager.GetUserId(User);
             _cartService.AddToCart(userId, productId, quantity);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.DeleteFromCart(userId, productId);
            return RedirectToAction("Index","Cart");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            var orderModel = new OrderModel();
            orderModel.CartModel = new CartModel()
            {
                CartId = cart.CartId,
                CartItems = cart.CartItems.Select(c => new CartItemModel()
                {
                    ProductId = c.ProductId,
                    CartItemId = c.ProductId,
                    Name = c.Product.Name,
                    Price = (double)c.Product.Price,
                    Quantity = c.Quantity,
                    ImageUrl = c.Product.ImageUrl
                }).ToList()
            };
           return View(orderModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var cart = _cartService.GetCartByUserId(userId);

                model.CartModel = new CartModel()
                {
                    CartId = cart.CartId,
                    CartItems = cart.CartItems.Select(c => new CartItemModel()
                    {
                        ProductId = c.ProductId,
                        CartItemId = c.ProductId,
                        Name = c.Product.Name,
                        Price = (double)c.Product.Price,
                        Quantity = c.Quantity,
                        ImageUrl = c.Product.ImageUrl
                    }).ToList()
                };

                var payment = PaymentProcess(model);
                if (payment.Status == "success")
                {
                    SaveOrder(model, payment, userId);
                    ClearCart(model.CartModel.CartId);
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Islem Basarili",
                        Message = $"{payment.PaymentId} no'lu odeme isleminiz tamamlanmistir.",
                        AlertType = AlertTypeEnum.Success
                    });
                    return View("Success");
                }
                else
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Islem Basarisiz",
                        Message = $"{payment.ErrorCode} - {payment.ErrorMessage}",
                        AlertType = AlertTypeEnum.Danger
                    });
                }
            }
            return View(model);
        }
        //TODO odeme tamamlandigi anda kullaniciya mail gonder
        //TODO kullaniciya fatura duzenle ve gonder
        [Authorize]
        private void ClearCart(int cartId)
        {
            _cartService.ClearCart(cartId);
        }

        [Authorize]
        private void SaveOrder(OrderModel model, Payment payment, string userId)
        {
            var order = new Order();
            order.OrderNumber = new Random().Next(111111, 999999).ToString();
            order.OrderState = EnumOrderState.completed;
            order.OrderDate = DateTime.Now;
            order.FirstName = model.FirstName;
            order.LastName = model.LastName;
            order.Email = model.Email;
            order.Phone = model.Phone;
            order.Address = model.Address;
            order.City = model.City;
            order.UserId = userId;
            order.Note = model.Note;

            foreach (var item in model.CartModel.CartItems)
            {
                var orderItem = new EntityLayer.OrderItem() 
                {
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ProductId = item.ProductId
                };
                order.OrderItems = new List<EntityLayer.OrderItem>();
                order.OrderItems.Add(orderItem);
            }
            _orderService.Create(order);
        }

        [Authorize]
        private Payment PaymentProcess(OrderModel model)
        {
            Options options = new Options();
            options.ApiKey = Configuration._configuration.GetSection("Iyzico:APIkey").Value;
            options.SecretKey = Configuration._configuration.GetSection("Iyzico:SecretKey").Value;
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111,999999999).ToString();
            request.Price = model.CartModel.TotalPrice().ToString();
            request.PaidPrice = model.CartModel.TotalPrice().ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = model.CardName;
            paymentCard.CardNumber = model.CardNumber;
            paymentCard.ExpireMonth = model.ExpirationMonth;
            paymentCard.ExpireYear = model.ExpirationYear;
            paymentCard.Cvc = model.Cvc;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            //paymentCard.CardNumber = "5528790000000008";
            //paymentCard.ExpireMonth = "12";
            //paymentCard.ExpireYear = "2030";
            //paymentCard.Cvc = "123";

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = model.FirstName;
            buyer.Surname = model.LastName;
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Izmir";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;

            foreach (var item in model.CartModel.CartItems)
            {
                basketItem = new BasketItem();
                basketItem.Id = item.ProductId.ToString();
                basketItem.Name = item.Name.ToString();
                basketItem.Category1 = "Collectibles";
                basketItem.Category2 = "Accessories";
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItem.Price = item.Price.ToString();
                basketItems.Add(basketItem);
            }
           
            request.BasketItems = basketItems;
            return Payment.Create(request, options);
        }
    }
}
