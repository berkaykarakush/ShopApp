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

        //TODO odeme sayfasinda varsa indirim kuponu
        //TODO orders process
        //TODO SignalR
        //TODO add open source email library 
        //TODO checout form add contract
        //TODO admin dasboard en cok satan urun
        //TODO admin dasboard en cok satis yapan magaza
        //TODO magaza sayfasi olustur
        //TODO user order listeleme
        //TODO admin tum orderlari goruntuleme
        //TODO seller order goruntuleme
        //TODO seller stock gorunutleme 
        //TODO seller satis bilgilerini goruntuleme
        //TODO seller siparis kargolandi ekleme
        //TODO seller siparis teslim edildi ekleme
        //TODO user kargom nerede
        //TODO admin komisyon

        [HttpGet]
        public async Task<IActionResult> Index(HomeIndexQueryRequest homeIndexQueryRequest)
        {
            HomeIndexQueryResponse response = await _mediator.Send(homeIndexQueryRequest);
            ProductListViewModel productListViewModel = _mapper.Map<ProductListViewModel>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            return View(productListViewModel);
        }
    }
}