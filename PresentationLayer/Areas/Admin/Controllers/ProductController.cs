using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Models;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;
        public ProductController(IMediator mediator, IMapper mapper, INotyfService notyfService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
        }

        [HttpGet]
        public async Task<IActionResult> ListProduct(AdminListProductQueryRequest listProductQueryRequest)
        {
            AdminListProductQueryResponse  response = await _mediator.Send(listProductQueryRequest);
            ListProductVM listProductVM = _mapper.Map<ListProductVM>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);

            return View(listProductVM);
        }
        
        [HttpGet]
        public async Task<IActionResult> CreateProduct(AdminCreateProductQueryRequest createProductQueryRequest)
        {
            AdminCreateProductQueryResponse response = await _mediator.Send(createProductQueryRequest);
            CreateProductVM createProductVM = _mapper.Map<CreateProductVM>(response);
            return View(createProductVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(AdminCreateProductCommandRequest createProductCommandRequest, IFormFileCollection files)
        {
            var imageUrls = await ImageNameEditExtensions.ImageNameEdit(files, UrlNameEditExtensions.UrlNameEdit(createProductCommandRequest.Name ?? string.Empty));
            createProductCommandRequest.Name = NameEditExtensions.NameEdit(createProductCommandRequest.Name ?? string.Empty);
            createProductCommandRequest.Url = UrlNameEditExtensions.UrlNameEdit(createProductCommandRequest.Name);
            createProductCommandRequest.ProductImage = imageUrls[0].Url?.ToString();

            foreach (var imageUrl in imageUrls) 
                createProductCommandRequest.ImageUrls.Add(imageUrl);

            if (ModelState.IsValid)
            {
                AdminCreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
                if (response.IsSuccess)
                {
                    _notyfService.Success($"Transaction Successfull - Product {response.ProductId} added.");
                    return RedirectToAction("Index", "Home");
                }

                _notyfService.Error(NotyfMessageEnum.Error);
                return View(response);
            }

            _notyfService.Error("Error - You entered incomplete information!");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(AdminEditProductQueryRequest editProductQueryRequest)
        {
            AdminEditProductQueryResponse response = await _mediator.Send(editProductQueryRequest);
            EditProductVM editProductVM = _mapper.Map<EditProductVM>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);

            return View(editProductVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(AdminEditProductCommandRequest editProductCommandRequest, IFormFileCollection files)
        {
            if (0 < files.Count)
            {
                var imageUrls = await ImageNameEditExtensions.ImageNameEdit(files, UrlNameEditExtensions.UrlNameEdit(editProductCommandRequest.Name));
                editProductCommandRequest.ProductImage = imageUrls[0].Url.ToString();
                editProductCommandRequest.ImageUrls.AddRange(imageUrls);
            }

            editProductCommandRequest.Name = NameEditExtensions.NameEdit(editProductCommandRequest.Name);
            editProductCommandRequest.Url = UrlNameEditExtensions.UrlNameEdit(editProductCommandRequest.Name);
            if (ModelState.IsValid)
            {
                AdminEditProductCommandResponse response = await _mediator.Send(editProductCommandRequest);
                EditProductVM editProductVM = _mapper.Map<EditProductVM>(response);

                if (!response.IsSuccess)
                    _notyfService.Error(NotyfMessageEnum.Error);
                else
                    _notyfService.Success("Transaction Successfull - Product Update!");

                return RedirectToAction("EditProduct", "Product", new AdminEditProductQueryRequest() { Id = editProductCommandRequest.ProductId });
            }
            _notyfService.Success($"Transaction Successfull - Product {editProductCommandRequest.ProductId} added.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(AdminDeleteProductCommandRequest deleteProductCommandRequest)
        {
            AdminDeleteProductCommandResponse response = await _mediator.Send(deleteProductCommandRequest);

            if (response.IsSuccess)
                _notyfService.Success($"Transaction Successfull - Item named {response.Name} has been deleted successfully!");
            else
                _notyfService.Error($"Error - There was an error trying to delete the item {response.Name}. Please, try again later!");

            return RedirectToAction("ListProduct", "Product");
        }
    }
}
