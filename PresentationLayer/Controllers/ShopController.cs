using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;
        readonly IMapper _mapper;
        public ShopController(IProductService productService, IMediator mediator, IMapper mapper)
        {
            _productService = productService;
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> TopSalesList(TopSalesListQueryRequest topSalesListQueryRequest)
        {
            TopSalesListQueryResponse response = await _mediator.Send(topSalesListQueryRequest);

            if (!response.IsSuccess)
                return NotFound();

            ProductListViewModel productViewModel = _mapper.Map<ProductListViewModel>(response);
            ProductVM productVM = _mapper.Map<ProductVM>(response.Products);
            productViewModel.Products.Add(productVM);
            return View(productViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> List(ShopListQueryRequest shopListQueryRequest)
        {
            ShopListQueryResponse response = await _mediator.Send(shopListQueryRequest);
            if (!response.IsSuccess)
                return NotFound();
            ListProductVM listProductVM = _mapper.Map<ListProductVM>(response);
            return View(listProductVM);
        }
        [HttpGet]
        public async Task<IActionResult> Details(ShopDetailsQueryRequest shopDetailsQueryRequest)
        {
            ShopDetailsQueryResponse response = await _mediator.Send(shopDetailsQueryRequest);
            if (!response.IsSuccess)
                return NotFound();
            ProductDetailModel productDetailModel = _mapper.Map<ProductDetailModel>(response);
            return View(productDetailModel);
        }

        [HttpGet]
        public async Task<IActionResult> Search(ShopSearchQueryRequest shopSearchQueryRequest)
        {
            ShopSearchQueryResponse response = await _mediator.Send(shopSearchQueryRequest);
            if (!response.IsSuccess)
                return NotFound();
            ListProductVM listProductVM = _mapper.Map<ListProductVM>(response);
            return View(listProductVM);
        }
    }
}
