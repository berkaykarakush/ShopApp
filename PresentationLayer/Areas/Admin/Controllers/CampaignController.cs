﻿using AspNetCoreHero.ToastNotification.Abstractions;
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
        public async Task<IActionResult> ListCampaign(AdminListCampaignQueryRequest listCampaignQueryRequest)
        {
            AdminListCampaignQueryResponse response = await _mediator.Send(listCampaignQueryRequest);

            if (!response.IsSuccess)
            {
                _notyfService.Error(NotyfMessageEnum.Error);
                return View();
            }

            ListCampaignVM listCampaignVM = _mapper.Map<ListCampaignVM>(response);
            return View(listCampaignVM);
        }

        [HttpGet]
        public IActionResult CreateCampaign()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCampaign(AdminCreateCamapignCommandRequest createCamapignCommandRequest, IFormFile file)
        {
            var imageUrl = await ImageNameEditExtensions.ImageNameEdit(file, UrlNameEditExtensions.UrlNameEdit(createCamapignCommandRequest.Name));
            createCamapignCommandRequest.Name = NameEditExtensions.NameEdit(createCamapignCommandRequest.Name);
            createCamapignCommandRequest.CampaignImage = imageUrl;

            AdminCreateCamapignCommandResponse response = await _mediator.Send(createCamapignCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Campaign created!");

            return RedirectToAction("ListCampaign", "Campaign");
        }

        [HttpGet]
        public async Task<IActionResult> EditCampaign(AdminEditCampaignQueryRequest editCampaignQueryRequest)
        {
            AdminEditCampaignQueryResponse response = await _mediator.Send(editCampaignQueryRequest);

            if (!response.IsSuccess)
            {
                _notyfService.Error(NotyfMessageEnum.Error);
                return View();
            }

            EditCampaignVM editCampaignVM = _mapper.Map<EditCampaignVM>(response);
            return View(editCampaignVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditCampaign(AdminEditCampaignCommandRequest editCampaignCommandRequest, IFormFile file)
        {
            var imageUrl = await ImageNameEditExtensions.ImageNameEdit(file, UrlNameEditExtensions.UrlNameEdit(editCampaignCommandRequest.Name ?? string.Empty));
            editCampaignCommandRequest.Name = NameEditExtensions.NameEdit(editCampaignCommandRequest.Name ?? string.Empty);
            editCampaignCommandRequest.CampaignImage = imageUrl;

            AdminEditCampaignCommandResponse response = await _mediator.Send(editCampaignCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Campaign updated!");

            return RedirectToAction("EditCampaign", "Campaign", new AdminEditCampaignQueryRequest() { CampaignId = editCampaignCommandRequest.CampaignId});
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCampaign(AdminDeleteCampaignCommandRequest deleteCampaignCommandRequest)
        {
            AdminDeleteCampaignCommandResponse response = await _mediator.Send(deleteCampaignCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Campaign deleted!");

            return RedirectToAction("ListCampaign", "Campaign");
        }
    }
}
