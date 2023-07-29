using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.VIewModels;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var productViewModel = new ProductListViewModel()
            {
                Products = _productService.GetHomePageProducts()
            };

            return View(productViewModel);
        }
        public IActionResult About() 
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        
    }
}