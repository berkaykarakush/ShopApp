using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> ListCategory(ListCategoryQueryRequest listCategoryQueryRequest)
        {
            ListCategoryQueryResponse response = await _mediator.Send(listCategoryQueryRequest);
            CategoryListViewModel categoryListViewModel = new CategoryListViewModel() { Categories = response.Categories };
            return View(categoryListViewModel);
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            createCategoryCommandRequest.Name = NameEditExtensions.NameEdit(createCategoryCommandRequest.Name);
            createCategoryCommandRequest.Url = UrlNameEditExtensions.UrlNameEdit(createCategoryCommandRequest.Name);

            CreateCategoryCommandResponse response = await _mediator.Send(createCategoryCommandRequest);

            if (response.IsSuccess)
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Transaction Successfull!",
                    Message = $"{createCategoryCommandRequest.Name} category has been created",
                    AlertType = AlertTypeEnum.Success
                });

            else
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Error!",
                    Message = $"Failed to create {createCategoryCommandRequest.Name} category",
                    AlertType = AlertTypeEnum.Danger
                });

            return RedirectToAction("ListCategory","Category");
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditCategory(EditCategoryQueryRequest editCategoryQueryRequest)
        {
            EditCategoryQueryResponse response = await _mediator.Send(editCategoryQueryRequest);
            CategoryVM categoryVM = _mapper.Map<CategoryVM>(response);
            return View(categoryVM);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditCategory(EditCategoryCommandRequest editCategoryCommandRequest)
        {
            editCategoryCommandRequest.Name = NameEditExtensions.NameEdit(editCategoryCommandRequest.Name);
            editCategoryCommandRequest.Url = UrlNameEditExtensions.UrlNameEdit(editCategoryCommandRequest.Name);
            EditCategoryCommandResponse response = await _mediator.Send(editCategoryCommandRequest);

            CategoryVM categoryVM = _mapper.Map<CategoryVM>(response);

            if (response.IsSuccess)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Category Name Updated",
                    Message = $"{editCategoryCommandRequest.Name} category has been updated",
                    AlertType = AlertTypeEnum.Success
                });
                return View(categoryVM);
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Category name could not be updated",
                Message = $"{editCategoryCommandRequest.Name} category has not been updated",
                AlertType = AlertTypeEnum.Danger
            });

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommandRequest deleteCategoryCommandRequest)
        {

            DeleteCategoryCommandResponse response = await _mediator.Send(deleteCategoryCommandRequest);
            if (response.IsSuccess)
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Category Deleted",
                    Message = $"{response.Name} category has been deleted successfully",
                    AlertType = AlertTypeEnum.Success
                });
            else
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Category not deleted!",
                    Message = $"{response.Name} category could not be deleted successfully",
                    AlertType = AlertTypeEnum.Danger
                });

            return RedirectToAction("ListCategory", "Category");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteFromCategory(DeleteFromCategoryCommandRequest deleteFromCategoryCommandRequest)
        {
            DeleteFromCategoryCommandResponse response = await _mediator.Send(deleteFromCategoryCommandRequest);
            if (response.IsSuccess)
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Transaction Successfull",
                    Message = $"Deleted!",
                    AlertType = AlertTypeEnum.Success
                });
            else
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Error!",
                    Message = $"Please try again later!",
                    AlertType = AlertTypeEnum.Danger
                });

            return Redirect("/admin/categories/" + deleteFromCategoryCommandRequest.categoryId);
        }
    }
}
