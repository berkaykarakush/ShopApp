using AutoMapper;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMediator _mediator;
        readonly IMapper _mapper;
        public ShopController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> TopSalesList(TopSalesListQueryRequest topSalesListQueryRequest)
        {
            TopSalesListQueryResponse response = await _mediator.Send(topSalesListQueryRequest);
            ProductListViewModel productViewModel = _mapper.Map<ProductListViewModel>(response);
            ProductVM productVM = _mapper.Map<ProductVM>(response.Products);
            productViewModel.Products.Add(productVM);

            if (!response.IsSuccess)
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Error!",
                    Message = "Please, try again later!",
                    AlertType = AlertTypeEnum.Danger
                });

            return View(productViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> List(ShopListQueryRequest shopListQueryRequest)
        {
            ShopListQueryResponse response = await _mediator.Send(shopListQueryRequest);
            ListProductVM listProductVM = _mapper.Map<ListProductVM>(response);
            
            if (!response.IsSuccess)
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Error!",
                    Message = "Please, try again later!",
                    AlertType = AlertTypeEnum.Danger
                });

            return View(listProductVM);
        }
        [HttpGet]
        public async Task<IActionResult> Details(ShopDetailsQueryRequest shopDetailsQueryRequest)
        {
            ShopDetailsQueryResponse response = await _mediator.Send(shopDetailsQueryRequest);

            if (!response.IsSuccess)
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Error!",
                    Message = "Please, try again later!",
                    AlertType = AlertTypeEnum.Danger
                });

            ProductDetailModel productDetailModel = _mapper.Map<ProductDetailModel>(response);
            return View(productDetailModel);
        }

        [HttpGet]
        public async Task<IActionResult> Search(ShopSearchQueryRequest shopSearchQueryRequest)
        {
            ShopSearchQueryResponse response = await _mediator.Send(shopSearchQueryRequest);

            if (!response.IsSuccess)
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Error!",
                    Message = "Please, try again later!",
                    AlertType = AlertTypeEnum.Danger
                });

            ListProductVM listProductVM = _mapper.Map<ListProductVM>(response);
            return View(listProductVM);
        }
    }
}
