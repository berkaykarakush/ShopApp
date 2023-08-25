using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using EntityLayer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class BrandController : Controller
    {
        private readonly IMediator _mediator;
        private readonly INotyfService _notyfService;
        private readonly IMapper _mapper;
        public BrandController(IMediator mediator, INotyfService notyfService, IMapper mapper)
        {
            _mediator = mediator;
            _notyfService = notyfService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ListBrand(ListBrandQueryRequest listBrandQueryRequest)
        {
            ListBrandQueryResponse response = await _mediator.Send(listBrandQueryRequest);
            ListBrandVM listBrandVM = _mapper.Map<ListBrandVM>(response); 

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            return View(listBrandVM);
        }
        
        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest createBrandCommandRequest)
        {
            CreateBrandCommandResponse response = await _mediator.Send(createBrandCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            _notyfService.Success("Transaction Successfull - Brand Created!");
            return RedirectToAction("ListBrand", "Brand");
        }
        
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(UpdateBrandQueryRequest updateBrandQueryRequest)
        {

            UpdateBrandQueryResponse response = await _mediator.Send(updateBrandQueryRequest);
            UpdateBrandVM updateBrandVM = _mapper.Map<UpdateBrandVM>(response.Brand);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            return View(updateBrandVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommandRequest updateBrandCommandRequest)
        {
            UpdateBrandCommandResponse response = await _mediator.Send(updateBrandCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            _notyfService.Success("Transaction Successfull - Brand Updated!");
            return View("ListBrand","Brand");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBrand(DeleteBrandCommandRequest deleteBrandCommandRequest) 
        {
            DeleteBrandCommandResponse response = await _mediator.Send(deleteBrandCommandRequest);

            if (!response.IsSuccess) 
                _notyfService.Error(NotfyMessageEnum.Error);

            _notyfService.Success("Transaction Successfull - Brand Deleted!");
            return RedirectToAction("ListBrand", "Brand");
        }
    }
}
