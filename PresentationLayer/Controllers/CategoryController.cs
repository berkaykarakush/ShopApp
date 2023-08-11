using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult ListCategory()
        {
            return View(new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll()
            });
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category
                {
                    Name = NameEditExtensions.NameEdit(model.Name),
                    Url = UrlNameEditExtensions.UrlNameEdit(model.Name),
                };

                if (_categoryService.Create(entity))
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Category Eklendi",
                        Message = $"{entity.Name} isimli category eklendi",
                        AlertType = AlertTypeEnum.Success
                    });
                }
                else
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Category Eklenemedi",
                        Message = $"{entity.Name} isimli category zaten mevcut lutfen yeni bir isim giriniz",
                        AlertType = AlertTypeEnum.Danger
                    });
                    return View(model);
                }
                return RedirectToAction("ListCategory", "Category");
            }
            return View(model);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _categoryService.GetByIdWithProducts((int)id);
            if (entity == null)
            {
                return NotFound();
            }

            var model = new CategoryModel()
            {
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                Url = entity.Url,
                Products = entity.ProductCategories.Select(p => p.Product).ToList()
            };
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _categoryService.GetById(model.CategoryId);
                if (entity == null)
                {
                    return NotFound();
                }

                entity.Name = NameEditExtensions.NameEdit(entity.Name);
                entity.Url = UrlNameEditExtensions.UrlNameEdit(entity.Name);

                if (_categoryService.Update(entity))
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Category Guncellendi",
                        Message = $"{entity.Name} isimli category guncellendi.",
                        AlertType = AlertTypeEnum.Success
                    });
                    return RedirectToAction("ListCategory", "Category");
                }
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Category Guncellenemedi",
                    Message = $"{entity.Name} isimli category zaten mevcut lutfen yeni bir isim giriniz.",
                    AlertType = AlertTypeEnum.Danger
                });
                return View(model);
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);
            if (entity != null)
            {
                _categoryService.Delete(entity);
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Category Silindi",
                Message = $"{entity.Name} isimli category silindi.",
                AlertType = AlertTypeEnum.Danger
            });

            return RedirectToAction("ListCategory", "Category");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteFromCategory(int productId, int categoryId)
        {
            _categoryService.DeleteFromCategory(productId, categoryId);
            return Redirect("/admin/categories/" + categoryId);
        }
    }
}
