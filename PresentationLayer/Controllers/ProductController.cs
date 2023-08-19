using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        IMediator _mediator;
        IMapper _mapper;
        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ListProduct(ListProductQueryRequest listProductQueryRequest)
        {
            ListProductQueryResponse  response = await _mediator.Send(listProductQueryRequest);
            ListProductVM listProductVM = _mapper.Map<ListProductVM>(response);
            return View(listProductVM);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest createProductCommandRequest, IFormFileCollection files)
        {
            var imageUrls = await ImageNameEditExtensions.ImageNameEdit(files, UrlNameEditExtensions.UrlNameEdit(createProductCommandRequest.Name));
            createProductCommandRequest.Name = NameEditExtensions.NameEdit(createProductCommandRequest.Name);
            createProductCommandRequest.Url = UrlNameEditExtensions.UrlNameEdit(createProductCommandRequest.Name);
            createProductCommandRequest.ProductImage = imageUrls[0].Url.ToString();

            foreach (var imageUrl in imageUrls) 
                createProductCommandRequest.ImageUrls.Add(imageUrl);

            if (ModelState.IsValid)
            {
                CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
                if (response.IsSuccess)
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Transaction Successfull",
                        Message = $"Product {response.ProductId} added.",
                        AlertType = AlertTypeEnum.Success
                    });
                    return RedirectToAction("Index", "Home");
                }

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Error",
                    Message = "An error occured while adding the product. Please, try again later!",
                    AlertType = AlertTypeEnum.Danger
                });
                return View(response);
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Error",
                Message = "You entered incomplete information!",
                AlertType = AlertTypeEnum.Danger
            });
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditProduct(EditProductQueryRequest editProductQueryRequest)
        {
            EditProductQueryResponse response = await _mediator.Send(editProductQueryRequest);
            EditProductVM editProductVM = new EditProductVM();
            editProductVM = response;//implicit type conversion
            return View(editProductVM);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditProduct(EditProductCommandRequest editProductCommandRequest, double[] categoryIds, IFormFileCollection files)
        {
            var imageUrls = await ImageNameEditExtensions.ImageNameEdit(files, UrlNameEditExtensions.UrlNameEdit(editProductCommandRequest.Name));
            editProductCommandRequest.Name = NameEditExtensions.NameEdit(editProductCommandRequest.Name);
            editProductCommandRequest.Url = UrlNameEditExtensions.UrlNameEdit(editProductCommandRequest.Name);
            editProductCommandRequest.ProductImage = imageUrls[0].Url.ToString();
            editProductCommandRequest.ImageUrls.AddRange(imageUrls);

            if (ModelState.IsValid)
            {
                EditProductCommandResponse response = await _mediator.Send(editProductCommandRequest);
                response.ImageUrls = editProductCommandRequest.ImageUrls;
                EditProductVM editProductVM = new EditProductVM();
                editProductVM = response;
                return View(editProductVM);
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Transaction Successfull",
                Message = $"Product {editProductCommandRequest.ProductId} added.",
                AlertType = AlertTypeEnum.Success
            });
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest deleteProductCommandRequest)
        {
            DeleteProductCommandResponse response = await _mediator.Send(deleteProductCommandRequest);

            if (response.IsSuccess)
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Product Deleted",
                    Message = $"Item named {response.Name} has been deleted successfully!",
                    AlertType = AlertTypeEnum.Success
                });
            else
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Product not deleted",
                    Message = $"There was an error trying to delete the item {response.Name}. Please, try again later!",
                    AlertType = AlertTypeEnum.Danger
                });

            return RedirectToAction("ListProduct", "Product");

    }
    }
}
