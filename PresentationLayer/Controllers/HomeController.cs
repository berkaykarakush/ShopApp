using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;
        public HomeController(IMediator mediator, IMapper mapper, INotyfService notyfService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(HomeIndexQueryRequest homeIndexQueryRequest)
        {
            HomeIndexQueryResponse response = await _mediator.Send(homeIndexQueryRequest);
            ProductListViewModel productListViewModel = _mapper.Map<ProductListViewModel>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            return View(productListViewModel);
        }

        [HttpGet]
        public IActionResult About() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        
    }
}