using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using NuGet.Protocol;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Models;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoreController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;

        public StoreController(IMediator mediator, IMapper mapper, INotyfService notyfService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> ListStore(AdminListStoreQueryRequest listStoreQueryRequest)
        {
            AdminListStoreQueryResponse response = await _mediator.Send(listStoreQueryRequest);
            ListStoreVM listStoreVM = _mapper.Map<ListStoreVM>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            
            return View(listStoreVM);
        }

        [HttpGet]
        public async Task<IActionResult> EditStore(AdminEditStoreQueryRequest editStoreQueryRequest)
        {
            AdminEditStoreQueryResponse response = await _mediator.Send(editStoreQueryRequest);
            EditStoreVM editStoreVM = _mapper.Map<EditStoreVM>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            return View(editStoreVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditStore(AdminEditStoreCommandRequest editStoreCommandRequest, IFormFileCollection files)
        {
            var imageUrls = await ImageNameEditExtensions.ImageNameEdit(files, UrlNameEditExtensions.UrlNameEdit(editStoreCommandRequest.StoreName));
            editStoreCommandRequest.StoreUrl = UrlNameEditExtensions.UrlNameEdit(editStoreCommandRequest.StoreName);
            editStoreCommandRequest.StoreImage = imageUrls[0].Url.ToString();
            editStoreCommandRequest.ImageUrls = imageUrls;

            AdminEditStoreCommandResponse response = await _mediator.Send(editStoreCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Store updated!");

            return RedirectToAction("EditStore", "Store", new AdminEditStoreQueryRequest() { StoreId = response.StoreId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStore(AdminDeleteStoreCommandRequest deleteStoreCommandRequest)
        {
            AdminDeleteStoreCommandResponse response = await _mediator.Send(deleteStoreCommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Store deleted!");

            return RedirectToAction("ListStore","Store");   
        }
    }
}
