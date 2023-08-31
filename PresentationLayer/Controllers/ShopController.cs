using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMediator _mediator;
        readonly IMapper _mapper;
        private readonly INotyfService _notyfService;

        public ShopController(IMediator mediator, IMapper mapper, INotyfService notyfService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
        }

        [HttpGet]
        public async Task<IActionResult> TopSalesList(TopSalesListQueryRequest topSalesListQueryRequest)
        {
            TopSalesListQueryResponse response = await _mediator.Send(topSalesListQueryRequest);
            ProductListViewModel productViewModel = _mapper.Map<ProductListViewModel>(response);
            ProductVM productVM = _mapper.Map<ProductVM>(response.Products);
            productViewModel.Products.Add(productVM);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            return View(productViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList(ShopCategoryListQueryRequest shopListQueryRequest)
        {
            ShopCategoryListQueryResponse response = await _mediator.Send(shopListQueryRequest);
            ListProductVM listProductVM = _mapper.Map<ListProductVM>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            return View(listProductVM);
        }

        [HttpGet]
        public IActionResult Category2List() 
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(ShopDetailsQueryRequest shopDetailsQueryRequest)
        {
            ShopDetailsQueryResponse response = await _mediator.Send(shopDetailsQueryRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            ProductDetailModel model  = _mapper.Map<ProductDetailModel>(response);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Search(ShopSearchQueryRequest shopSearchQueryRequest)
        {
            ShopSearchQueryResponse response = await _mediator.Send(shopSearchQueryRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            ListProductVM listProductVM = _mapper.Map<ListProductVM>(response);
            return View(listProductVM);
        }
    }
}
