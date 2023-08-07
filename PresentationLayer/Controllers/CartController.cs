using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Identity;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private UserManager<User> _userManager;

        public CartController(ICartService cartService, UserManager<User> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            return View(new CartModel()
            {
                CartId = cart.Id,
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
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var userId = _userManager.GetUserId(User);
             _cartService.AddToCart(userId, productId, quantity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.DeleteFromCart(userId, productId);
            return RedirectToAction("Index","Cart");
        }
    }
}
