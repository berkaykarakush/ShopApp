using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Seller.Models;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;

namespace PresentationLayer.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class CampaignController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;

        public CampaignController(IMediator mediator, IMapper mapper, INotyfService notyfService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
        }

        [HttpGet]
        public async Task<IActionResult> ListCampaign(SellerListCampaignQueryRequest sellerListCampaignQueryRequest)
        {
            SellerListCampaignQueryResponse response = await _mediator.Send(sellerListCampaignQueryRequest);

            if (!response.IsSuccess)
            {
                _notyfService.Error(NotyfMessageEnum.Error);
                return View();
            }
            SellerListCampaignVM sellerListCampaignVM = _mapper.Map<SellerListCampaignVM>(response);
            return View(sellerListCampaignVM);
        }

        [HttpGet]
        public IActionResult CreateCampaign() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCampaign(SellerCreateCampaignCommandRequest sellerCreateCampaignCommandRequest, IFormFile file)
        {
            var imageUrl = await ImageNameEditExtensions.ImageNameEdit(file, UrlNameEditExtensions.UrlNameEdit(sellerCreateCampaignCommandRequest.Name ?? string.Empty));
            sellerCreateCampaignCommandRequest.CampaignImage = imageUrl;

            SellerCreateCampaignCommandResponse response = await _mediator.Send(sellerCreateCampaignCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Campaign created!");

            return RedirectToAction("ListCampaign","Campaign");
        }

        [HttpGet]
        public async Task<IActionResult> EditCampaign(SellerEditCampaignQueryRequest sellerEditCampaignQueryRequest)
        {
            SellerEditCampaignQueryResponse response = await _mediator.Send(sellerEditCampaignQueryRequest);

            if (!response.IsSuccess)
            {
                _notyfService.Error(NotyfMessageEnum.Error);
                return View();
            }
            SellerEditCampaignVM sellerEditCampaignVM = _mapper.Map<SellerEditCampaignVM>(response);
            return View(sellerEditCampaignVM);
        }
        [HttpPost]
        public async Task<IActionResult> EditCampaign(SellerEditCampaignCommandRequest sellerEditCampaignCommandRequest)
        {
            SellerEditCampaignCommandResponse response = await _mediator.Send(sellerEditCampaignCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);
            else
                _notyfService.Success("Transaction successfull - Campaign updated!");
               
            return RedirectToAction("ListCampaign","Campaign");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCampaign(SellerDeleteCampaignCommandRequest sellerDeleteCampaignCommandRequest)
        {
            SellerDeleteCampaignCommandResponse response = await _mediator.Send(sellerDeleteCampaignCommandRequest);
            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);
            else
                _notyfService.Success("Transaction successfull - Campaign deleted!");

            return RedirectToAction("ListCampaign","Campaign");
        }
    }
}
