﻿using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.VIewModels;

namespace PresentationLayer.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult List(string category, int page=1)
        {
            const int pageSize = 2;    
            var productViewModel = new ProductListViewModel()
            {
                PageInfo = new PageInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category,
                    TotalItems = _productService.GetCountByCategory(category)
                },
                Products = _productService.GetProductsByCategory(category, page, pageSize)
            };

            return View(productViewModel);
        }
        public IActionResult Details(string url)
        {
            if (url == null)
                return NotFound();

            Product product = _productService.GetProductDetails(url);

            if (product==null)
                return NotFound();

            return View(new ProductDetailModel{
                Product = product,
                Categories = product.ProductCategories.Select(p => p.Category).ToList() 
            });
        }

        public IActionResult Search(string q)
        {
            var productViewModel = new ProductListViewModel()
            {
                Products = _productService.GetSearchResult(q)
            };

            return View(productViewModel);
        }
    }
}