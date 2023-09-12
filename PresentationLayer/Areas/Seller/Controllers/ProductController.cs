using AspNetCore;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Seller.Models;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Identity;

namespace PresentationLayer.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;
        private readonly UserManager<User> _userManager;
        public ProductController(IMediator mediator, IMapper mapper, INotyfService notyfService, UserManager<User> userManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
            _userManager = userManager;
        }

        //[Route("Seller/Product/ListProduct")]
        [HttpGet]
        public async Task<IActionResult> ListProduct(SellerListProductQueryRequest sellerListProductQueryRequest)
        {
            var user = await _userManager.GetUserAsync(User);
            sellerListProductQueryRequest.SellerId = user.Id;
            SellerListProductQueryResponse response = await _mediator.Send(sellerListProductQueryRequest);

            if (!response.IsSucces)
                _notyfService.Error(NotfyMessageEnum.Error);

            SellerListProductVM sellerListProductVM = _mapper.Map<SellerListProductVM>(response);
            return View(sellerListProductVM);
        }

        //[Route("Seller/Product/CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct(SellerCreateProductQueryRequest sellerCreateProductQueryRequest)
        {
            SellerCreateProductQueryResponse response = await _mediator.Send(sellerCreateProductQueryRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            SellerCreateProductVM sellerCreateProductVM = _mapper.Map<SellerCreateProductVM>(response);
            return View(sellerCreateProductVM);
        }

        //[Route("Seller/Product/CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(SellerCreateProductCommandRequest sellerCreateProductCommandRequest, IFormFileCollection files)
        {
            var user = await _userManager.GetUserAsync(User);
            sellerCreateProductCommandRequest.SellerId = user.Id;

            var imageUrls = await ImageNameEditExtensions.ImageNameEdit(files, UrlNameEditExtensions.UrlNameEdit(sellerCreateProductCommandRequest.Name ?? string.Empty));
            sellerCreateProductCommandRequest.Name = NameEditExtensions.NameEdit(sellerCreateProductCommandRequest.Name ?? string.Empty);
            sellerCreateProductCommandRequest.Url = UrlNameEditExtensions.UrlNameEdit(sellerCreateProductCommandRequest.Name);
            sellerCreateProductCommandRequest.ProductImage = imageUrls[0].Url?.ToString();

            foreach (var imageUrl in imageUrls)
                sellerCreateProductCommandRequest.ImageUrls.Add(imageUrl);

            SellerCreateProductCommandResponse response = await _mediator.Send(sellerCreateProductCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Product Created!");

            return RedirectToAction("ListProduct", "Product");
        }

        //[Route("Seller/Product/EditProduct?ProductId=")]
        [HttpGet]
        public async Task<IActionResult> EditProduct(SellerEditProductQueryRequest sellerEditProductQueryRequest)
        {
            SellerEditProductQueryResponse response = await _mediator.Send(sellerEditProductQueryRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            SellerEditProductVM sellerEditProductVM = _mapper.Map<SellerEditProductVM>(response);
            return View(sellerEditProductVM);
        }

        //[Route("Seller/Product/EditProduct?ProductId=")]
        [HttpPost]
        public async Task<IActionResult> EditProduct(SellerEditProductCommandRequest sellerEditProductCommandRequest, IFormFileCollection files)
        {
            var user = await _userManager.GetUserAsync(User);
            sellerEditProductCommandRequest.UserId = user.Id;

            var imageUrls = await ImageNameEditExtensions.ImageNameEdit(files, UrlNameEditExtensions.UrlNameEdit(sellerEditProductCommandRequest.Name ?? string.Empty));
            sellerEditProductCommandRequest.Name = NameEditExtensions.NameEdit(sellerEditProductCommandRequest.Name ?? string.Empty);
            sellerEditProductCommandRequest.Url = UrlNameEditExtensions.UrlNameEdit(sellerEditProductCommandRequest.Name);
            sellerEditProductCommandRequest.ProductImage = imageUrls[0].Url?.ToString();

            foreach (var imageUrl in imageUrls)
                sellerEditProductCommandRequest.ImageUrls?.Add(imageUrl);

            SellerEditProductCommandResponse response = await _mediator.Send(sellerEditProductCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Product Updated!");

            return RedirectToAction("EditProduct", "Product", new SellerEditProductQueryRequest() { Id = sellerEditProductCommandRequest.ProductId });

        }

        //[Route("Seller/Product/DeleteProduct/{ProductId}")]
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(SellerDeleteProductCommandRequest sellerDeleteProductCommandRequest)
        {
            SellerDeleteProductCommandResponse response = await _mediator.Send(sellerDeleteProductCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Product Deleted!");

            return RedirectToAction("ListProduct", "Product");
        }
    }
}
