using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using PresentationLayer.Enums;
using PresentationLayer.Models;

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
                _notyfService.Error(NotyfMessageEnum.Error);

            return View(productViewModel);
        }

        //[Route("Shop/CategoryList?category=")]
        [HttpGet]
        public async Task<IActionResult> CategoryList(ShopCategoryListQueryRequest shopListQueryRequest)
        {
            ShopCategoryListQueryResponse response = await _mediator.Send(shopListQueryRequest);
            ListProductVM listProductVM = _mapper.Map<ListProductVM>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);
            return View(listProductVM);
        }

        //[Route("Shop/Category2List?category2=")]
        [HttpGet]
        public async Task<IActionResult> Category2List(ShopCategory2ListQueryRequest shopCategory2ListQueryRequest) 
        {
            ShopCategory2ListQueryResponse response = await _mediator.Send(shopCategory2ListQueryRequest);
            ListProductVM listProductVM = _mapper.Map<ListProductVM>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);

            return View(listProductVM);
        }

        //[Route("Shop/BrandList?brand=")]
        [HttpGet]
        public async Task<IActionResult> BrandList(ShopBrandListQueryRequest shopBrandListQueryRequest)
        {
            ShopBrandListQueryResponse response = await _mediator.Send(shopBrandListQueryRequest);
            ListProductVM listProductVM = _mapper.Map<ListProductVM>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);

            return View(listProductVM);
        }

        //[Route("Shop/StoreList?store=)]
        [HttpGet]
        public async Task<IActionResult> StoreList(ShopStoreListQueryRequest shopStoreListQueryRequest)
        {        //[Route("Shop/StoreHome?store=")]
            ShopStoreListQueryResponse response = await _mediator.Send(shopStoreListQueryRequest);
            ListProductVM listProductVM = _mapper.Map<ListProductVM>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);

            return View(listProductVM);
        }


        [HttpGet]
        public async Task<IActionResult> StoreHome(ShopStoreHomeQueryRequest shopStoreHomeQueryRequest)
        {
            ShopStoreHomeQueryResponse response = await _mediator.Send(shopStoreHomeQueryRequest);
            StoreHomeVM storeHomeVM = _mapper.Map<StoreHomeVM>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);

            return View(storeHomeVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details(ShopDetailsQueryRequest shopDetailsQueryRequest)
        {
            ShopDetailsQueryResponse response = await _mediator.Send(shopDetailsQueryRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);

            ProductDetailModel model  = _mapper.Map<ProductDetailModel>(response);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Search(ShopSearchQueryRequest shopSearchQueryRequest)
        {
            ShopSearchQueryResponse response = await _mediator.Send(shopSearchQueryRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);

            ListProductVM listProductVM = _mapper.Map<ListProductVM>(response);
            return View(listProductVM);
        }
    }
}
