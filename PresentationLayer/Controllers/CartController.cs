using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.EFCore;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using EntityLayer;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using MediatR;
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
        private readonly IStoreService _storeService;
        private readonly IEmailSender _emailSender;
        private readonly IProductService _productService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private UserManager<User> _userManager;
        private readonly INotyfService _notyfService;
        public CartController(ICartService cartService, UserManager<User> userManager, IOrderService orderService, IEmailSender emailSender, IProductService productService, IMediator mediator, IMapper mapper, INotyfService notyfService, IStoreService storeService)
        {
            _cartService = cartService;
            _userManager = userManager;
            _orderService = orderService;
            _emailSender = emailSender;
            _productService = productService;
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
            _storeService = storeService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index(CartIndexQueryRequest cartIndexQueryRequest)
        {
            var user = await _userManager.GetUserAsync(User);
            cartIndexQueryRequest.UserId = user.Id;

            CartIndexQueryResponse response = await _mediator.Send(cartIndexQueryRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);

            CartVM cartModel = _mapper.Map<CartVM>(response);
            return View(cartModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToCart(AddToCartCommandRequest addToCartCommandRequest)
        {
            var userId = _userManager.GetUserId(User);
            addToCartCommandRequest.UserId = userId;

            AddToCartCommandResponse response = await _mediator.Send(addToCartCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Product added to cart");

            return RedirectToAction("Details", "Shop",new ShopDetailsQueryRequest() { Url = response.Url ?? string.Empty});
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteFromCart(DeleteFromCartCommandRequest deleteFromCartCommandRequest)
        {
            string userId = _userManager.GetUserId(User);
            deleteFromCartCommandRequest.UserId = userId;
            DeleteFromCartCommandResponse response = await _mediator.Send(deleteFromCartCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Item deleted!");

            return RedirectToAction("Index", "Cart");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Checkout(CheckoutQueryRequest checkoutQueryRequest)
        {
            string userId = _userManager.GetUserId(User);
            checkoutQueryRequest.UserId = userId;

            CheckoutQueryResponse response = await _mediator.Send(checkoutQueryRequest);

            if (!response.IsSuccess)
            {
                _notyfService.Error(NotyfMessageEnum.Error);
                return View();
            }

            CreateOrderVM orderModel = _mapper.Map<CreateOrderVM>(response);
            return View(orderModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Checkout(CreateOrderVM model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var cart = _cartService.GetCartByUserId(userId);

                model.Cart = new CartVM()
                {
                    CartId = cart.CartId,
                    CartItems = cart.CartItems.Select(c => new CartItemModel()
                    {
                        ProductId = c.ProductId,
                        CartItemId = c.ProductId,
                        ProductName = c.Product.Name,
                        Price = c.Product.Price,
                        Quantity = c.Quantity,
                        ProductImage = c.Product.ProductImage
                    }).ToList(),
                };

                var payment = PaymentProcess(model);
                if (payment.Status == "success")
                {
                    SaveOrder(model, payment, userId, model.StoreIds);
                    await OrderState(model, EnumOrderState.waiting);
                    DecreaseQuantity(model);
                    _cartService.ClearCart(model.Cart.CartId);
                    IncreaseProductSaleCount(model);

                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        user.UserAddresses.Add(new UserAddress()
                        {
                            UserId = userId,
                            Address = model.Address,
                            City = model.City,
                            Country = model.City,
                            ZipCode = model.ZipCode
                        });
                        await _userManager.UpdateAsync(user);
                    }

                    _notyfService.Success($"Transaction Successfull - Your payment transaction number {payment.PaymentId} has been completed.");
                    return View("Success");
                }
                else
                    _notyfService.Error($"Error - {payment.ErrorCode} - {payment.ErrorMessage}");
            }
            return RedirectToAction("Checkout", "Cart");
        }

        [HttpPost]

        public async Task<IActionResult> Discount(DiscountCommandRequest discountCommandRequest)
        {
            DiscountCommandResponse response = await _mediator.Send(discountCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Code implemented!");

            return RedirectToAction("Checkout", "Cart", new CheckoutQueryRequest() { Code = discountCommandRequest.Code});
        }

        private void IncreaseProductSaleCount(CreateOrderVM model)
        {
            foreach (var p in model.Cart.CartItems)
            {
                var product = _productService.GetById((double)p.ProductId);
                if (product != null)
                {
                    product.SalesCount += p.Quantity;
                    _productService.Update(product);
                }
            }
        }

        [Authorize]
        private void DecreaseQuantity(CreateOrderVM model)
        {
            foreach (var i in model.Cart.CartItems)
            {
                var product = _productService.GetById((double)i.ProductId);

                if (product.Quantity < i.Quantity)
                {
                    _notyfService.Error($"Error - {product.Name} - Quantity entered is more than the product in the stock.");
                }

                if (product.Quantity > 0)
                {
                    product.Quantity -= i.Quantity;
                    _productService.Update(product);
                }
                else
                {
                    _notyfService.Error($"Error - {product.Name} has no stock.");
                }
            }
        }

        [Authorize]
        private void SaveOrder(CreateOrderVM model, Payment payment, string userId, List<double> storeIds)
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
            order.TermsAndConditions = model.TermsAndConditions;

            foreach (var item in storeIds)
            {
                var store = _storeService.GetById(item);
                order.Stores?.Add(store);
            }

            foreach (var item in model.Cart.CartItems)
            {
                var orderItem = new EntityLayer.OrderItem()
                {
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ProductId = item.ProductId
                };
                order.OrderItems?.Add(orderItem);
            }
            _orderService.Create(order);
        }

        [Authorize]
        private Payment PaymentProcess(CreateOrderVM model)
        {
            Options options = new Options();
            options.ApiKey = Configuration._configuration.GetSection("Iyzico:APIkey").Value;
            options.SecretKey = Configuration._configuration.GetSection("Iyzico:SecretKey").Value;
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111, 999999999).ToString();
            request.Price = model.Cart.TotalPrice.ToString();
            request.PaidPrice = model.Cart.TotalPrice.ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = model.Cart.CartId.ToString();
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
            buyer.GsmNumber = $"+90{model.Phone}";
            buyer.Email = model.Email;
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = model.Address;
            buyer.Ip = GetPublicIPAddress.GetIPAddress();
            buyer.City = model.City;
            buyer.Country = model.Country;
            buyer.ZipCode = model.ZipCode;
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = $"{model.FirstName} {model.LastName}";
            shippingAddress.City = model.City;
            shippingAddress.Country = model.Country;
            shippingAddress.Description = model.Address;
            shippingAddress.ZipCode = model.ZipCode;
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = $"{model.FirstName} {model.LastName}";
            billingAddress.City = model.City;
            billingAddress.Country = model.Country;
            billingAddress.Description = model.Address;
            billingAddress.ZipCode = model.ZipCode;
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;

            foreach (var item in model.Cart.CartItems)
            {
                basketItem = new BasketItem();
                basketItem.Id = item.ProductId.ToString();
                basketItem.Name = item.ProductName.ToString();
                basketItem.Category1 = "Collectibles";
                basketItem.Category2 = "Accessories";
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItem.Price = (item.Price * item.Quantity).ToString();
                basketItems.Add(basketItem);
            }

            request.BasketItems = basketItems;
            return Payment.Create(request, options);
        }

        [Authorize]
        public async Task<EnumOrderState> OrderState(CreateOrderVM model, EnumOrderState state)
        {
            EnumOrderState _state = state;

            switch (_state)
            {
                case EnumOrderState.waiting:
                    await _emailSender.SendEmailAsync(model.Email, "You order has been received", $"Your order number {model.Cart.CartId} has reached us.");
                    break;
                case EnumOrderState.shipped:
                    await _emailSender.SendEmailAsync(model.Email, "Your order has been shipped", $"Your order number {model.Cart.CartId} has been delivered to cargo.");
                    break;
                case EnumOrderState.completed:
                    await _emailSender.SendEmailAsync(model.Email,"Your order has been delivered",$"Your cargo number {model.Cart.CartId} has been delivered.");
                    break;
                default:
                    break;
            }
            return _state;
        }
    }
}
