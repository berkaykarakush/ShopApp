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
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly Serilog.ILogger _logger;

        public HomeController(IMediator mediator, IMapper mapper, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(HomeIndexQueryRequest homeIndexQueryRequest)
        {
            _logger.Information("Home Index trigged");
            HomeIndexQueryResponse response = await _mediator.Send(homeIndexQueryRequest);
            ProductListViewModel productListViewModel = _mapper.Map<ProductListViewModel>(response);

            if (!response.IsSuccess)
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Error!",
                    Message = "Please try again later!",
                    AlertType = AlertTypeEnum.Danger
                });

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