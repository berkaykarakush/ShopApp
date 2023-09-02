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
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyfService;
        public CategoryController(IMediator mediator, IMapper mapper, INotyfService notyfService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notyfService = notyfService;
        }

        [HttpGet]
        public async Task<IActionResult> ListCategory(ListCategoryQueryRequest listCategoryQueryRequest)
        {
            ListCategoryQueryResponse response = await _mediator.Send(listCategoryQueryRequest);
            CategoryListViewModel categoryListViewModel = _mapper.Map<CategoryListViewModel>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            return View(categoryListViewModel);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            createCategoryCommandRequest.Name = NameEditExtensions.NameEdit(createCategoryCommandRequest.Name);
            createCategoryCommandRequest.Url = UrlNameEditExtensions.UrlNameEdit(createCategoryCommandRequest.Name);

            CreateCategoryCommandResponse response = await _mediator.Send(createCategoryCommandRequest);

            if (response.IsSuccess)
                _notyfService.Success($"Transaction Successfull - {createCategoryCommandRequest.Name} category has been created");

            else
                _notyfService.Error($"Error - Failed to create {createCategoryCommandRequest.Name} category");
            return RedirectToAction("ListCategory","Category");
        }
        
        [HttpGet]
        public async Task<IActionResult> EditCategory(EditCategoryQueryRequest editCategoryQueryRequest)
        {
            EditCategoryQueryResponse response = await _mediator.Send(editCategoryQueryRequest);
            CategoryVM categoryVM = _mapper.Map<CategoryVM>(response);

            if (!response.IsSuccess)
                _notyfService.Error(NotfyMessageEnum.Error);

            return View(categoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(EditCategoryCommandRequest editCategoryCommandRequest)
        {
            editCategoryCommandRequest.Name = NameEditExtensions.NameEdit(editCategoryCommandRequest.Name);
            editCategoryCommandRequest.Url = UrlNameEditExtensions.UrlNameEdit(editCategoryCommandRequest.Name);
            EditCategoryCommandResponse response = await _mediator.Send(editCategoryCommandRequest);

            CategoryVM categoryVM = _mapper.Map<CategoryVM>(response);

            if (response.IsSuccess)
            {
                _notyfService.Success($"Transaction Successfull - {editCategoryCommandRequest.Name} category has been updated");
                return View(categoryVM);
            }
            
            _notyfService.Error($"Error - {editCategoryCommandRequest.Name} category has not been updated");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommandRequest deleteCategoryCommandRequest)
        {

            DeleteCategoryCommandResponse response = await _mediator.Send(deleteCategoryCommandRequest);
            if (response.IsSuccess)
                _notyfService.Success($"Transaction Successfull - {response.Name} category has been deleted successfully");
            else
                _notyfService.Error($"Error - {response.Name} category could not be deleted successfully");

            return RedirectToAction("ListCategory", "Category");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFromCategory(DeleteFromCategoryCommandRequest deleteFromCategoryCommandRequest)
        {
            DeleteFromCategoryCommandResponse response = await _mediator.Send(deleteFromCategoryCommandRequest);

            if (response.IsSuccess)
                _notyfService.Success("Transaction Successfull - Category Deleted");
            else
                _notyfService.Error(NotfyMessageEnum.Error);

            return Redirect("/admin/categories/" + deleteFromCategoryCommandRequest.categoryId);
        }
    }
}
