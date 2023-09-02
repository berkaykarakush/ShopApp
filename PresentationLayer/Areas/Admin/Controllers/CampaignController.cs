using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Models;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> ListCampaign(ListCampaignQueryRequest listCampaignQueryRequest)
        {
            ListCampaignQueryResponse response = await _mediator.Send(listCampaignQueryRequest);
            ListCampaignVM listCampaignVM = _mapper.Map<ListCampaignVM>(response);
            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            return View(listCampaignVM);
        }

        [HttpGet]
        public IActionResult CreateCampaign()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCampaign(CreateCamapignCommandRequest createCamapignCommandRequest, IFormFileCollection file)
        {
            var imageUrls = await ImageNameEditExtensions.ImageNameEdit(file, UrlNameEditExtensions.UrlNameEdit(createCamapignCommandRequest.Name));
            createCamapignCommandRequest.Name = NameEditExtensions.NameEdit(createCamapignCommandRequest.Name);
            createCamapignCommandRequest.CampaignImage = imageUrls[0].Url.ToString();

            foreach (var imageUrl in imageUrls)
                createCamapignCommandRequest.ImageUrls.Add(imageUrl);

            CreateCamapignCommandResponse response = await _mediator.Send(createCamapignCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            return RedirectToAction("ListCampaign", "Campaign");
        }

        [HttpGet]
        public async Task<IActionResult> EditCampaign(EditCampaignQueryRequest editCampaignQueryRequest)
        {
            EditCampaignQueryResponse response = await _mediator.Send(editCampaignQueryRequest);
            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            EditCampaignVM editCampaignVM = _mapper.Map<EditCampaignVM>(response);
            return View(editCampaignVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditCampaign(EditCampaignCommandRequest editCampaignCommandRequest, IFormFileCollection file)
        {
            var imageUrls = await ImageNameEditExtensions.ImageNameEdit(file, UrlNameEditExtensions.UrlNameEdit(editCampaignCommandRequest.Name));
            editCampaignCommandRequest.Name = NameEditExtensions.NameEdit(editCampaignCommandRequest.Name);
            editCampaignCommandRequest.CampaignImage = imageUrls[0].Url.ToString();

            foreach (var imageUrl in imageUrls)
                editCampaignCommandRequest.ImageUrls.Add(imageUrl);

            EditCampaignCommandResponse response = await _mediator.Send(editCampaignCommandRequest);
            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            EditCampaignVM editCampaignVM = _mapper.Map<EditCampaignVM>(response);
            return View(editCampaignVM);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCampaign(DeleteCampaignCommandRequest deleteCampaignCommandRequest)
        {
            DeleteCampaignCommandResponse response = await _mediator.Send(deleteCampaignCommandRequest);
            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            return RedirectToAction("ListCampaign", "Campaign");
        }
    }
}
