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
using System.Data;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class Category2Controller : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;

        public Category2Controller(IMediator mediator, IMapper mapper, INotyfService notyfService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
        }

        [HttpGet]
        public async Task<IActionResult> ListCategory2(ListCategory2QueryRequest listCategory2QueryRequest)
        {
            ListCategory2QueryResponse response = await _mediator.Send(listCategory2QueryRequest);
            Category2ListVM category2ListVM = _mapper.Map<Category2ListVM>(response);
            return View(category2ListVM);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCategory2(CreateCategory2QueryRequest createCategory2QueryRequest) 
        {
            CreateCategory2QueryResponse response = await _mediator.Send(createCategory2QueryRequest);

            if (!response.IsSuccess)
            {
                _notyfService.Error(NotyfMessageEnum.Error);
                return View();
            }

            CreateCategory2VM createCategory2VM = _mapper.Map<CreateCategory2VM>(response);

            return View(createCategory2VM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory2(CreateCategory2CommandRequest createCategory2CommandRequest)
        {
            if (!ModelState.IsValid)
                ModelState.AddModelError("", "Name is required!");

            if (string.IsNullOrEmpty(createCategory2CommandRequest.Name))
                return View();

            createCategory2CommandRequest.Url = UrlNameEditExtensions.UrlNameEdit(createCategory2CommandRequest.Name);

            CreateCategory2CommandResponse response = await _mediator.Send(createCategory2CommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Category Added!");

            return RedirectToAction("ListCategory2", "Category2");
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory2(EditCategory2QueryRequest editCategory2QueryRequest)
        {
            EditCategory2QueryResponse response = await _mediator.Send(editCategory2QueryRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);

            EditCategory2VM editCategory2VM = _mapper.Map<EditCategory2VM>(response);
            return View(editCategory2VM);
        }
        [HttpPost]
        public async Task<IActionResult> EditCategory2(EditCategory2CommandRequest editCategory2CommandRequest)
        {
            if (string.IsNullOrEmpty(editCategory2CommandRequest.Name))
                _notyfService.Error(NotyfMessageEnum.Error);
            else
                editCategory2CommandRequest.Url = UrlNameEditExtensions.UrlNameEdit(editCategory2CommandRequest.Name);

            EditCategory2CommandResponse response = await _mediator.Send(editCategory2CommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Category Updated!");

            return RedirectToAction("EditCategory2","Category2", new EditCategory2QueryRequest() { Category2Id = editCategory2CommandRequest.Category2Id});
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory2(DeleteCategory2CommandRequest deleteCategory2CommandRequest)
        {
            DeleteCategory2CommandResponse response = await _mediator.Send(deleteCategory2CommandRequest);

            if (!response.IsSuccess)
                _notyfService.Error(NotyfMessageEnum.Error);
            else
                _notyfService.Success("Transaction Successfull - Category Deleted!");

            return RedirectToAction("ListCategory2", "Category2");
        }
    }
}
