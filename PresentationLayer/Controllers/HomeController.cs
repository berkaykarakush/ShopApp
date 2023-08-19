using AutoMapper;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(HomeIndexQueryRequest homeIndexQueryRequest)
        {
            HomeIndexQueryResponse response = await _mediator.Send(homeIndexQueryRequest);
            ProductListViewModel productListViewModel = _mapper.Map<ProductListViewModel>(response);
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