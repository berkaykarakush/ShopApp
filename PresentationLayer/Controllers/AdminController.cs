using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        #region Product
        public IActionResult ListProduct()
        {
            return View(new ProductListViewModel()
            {
                Products = _productService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModel model, IFormFile file) 
        {
            bool errors = ModelState.Values.Any(m => m.Errors.Count == 0);
            if (ModelState.IsValid)
            {
                var entity = new Product
                {
                    Name = model.Name,
                    Url = model.Url,
                    Description = model.Description,
                    Price = model.Price,
                    ImageUrl = model.ImageUrl,
                };

                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extension}");
                    entity.ImageUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);


                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                if (_productService.Create(entity))
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Islem Basarili",
                        Message = $"{entity.Name} urun eklendi",
                        AlertType = AlertTypeEnum.Success
                    });
                    return RedirectToAction("ListProduct");
                }
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Hata",
                    Message = "urun adi girmelisiniz",
                    AlertType = AlertTypeEnum.Danger
                });
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _productService.GetByIdWithCategories((int)id);
            if (entity == null)
            {
                return NotFound();
            }

            var model = new ProductModel()
            {
                ProductId = entity.ProductId,
                Name = entity.Name,
                Url = entity.Url,
                Description = entity.Description,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                IsApproved = entity.IsApproved,
                IsHome = entity.IsHome,
                SelectedCategories = entity.ProductCategories.Select(pc => pc.Category).ToList()
            };

            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult EditProduct(ProductModel model, int[] categoryIds)
        {
            bool errors = ModelState.Values.Any(m => m.Errors.Count == 0);

            if (ModelState.IsValid)
            {
                var entity = _productService.GetById(model.ProductId);
                if (entity == null)
                {
                    return NotFound();
                }

                entity.Name = model.Name;
                entity.Url = model.Url;
                entity.Description = model.Description;
                entity.Price = model.Price;
                entity.ImageUrl = model.ImageUrl;
                entity.IsApproved = model.IsApproved;
                entity.IsHome = model.IsHome;

                if (_productService.Update(entity, categoryIds))
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Islem Basarili",
                        Message = $"{entity.Name} isimli urun guncellendi.",
                        AlertType = AlertTypeEnum.Success
                    });
                    return RedirectToAction("ListProduct");
                }
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Hata",
                    Message = _productService.ErrorMessage.ToString(),
                    AlertType = AlertTypeEnum.Danger
                });
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }
        public IActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);
            if (entity != null)
            {
                _productService.Delete(entity);
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Urun Silindi",
                Message = $"{entity.Name} isimli urun silindi.",
                AlertType = AlertTypeEnum.Danger
            });
            return RedirectToAction("ListProduct");
        }
        #endregion
        #region Category
        public IActionResult ListCategory()
        {
            return View(new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category
                {
                    Name = model.Name,
                    Url = model.Url,
                };

                _categoryService.Create(entity);

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Category Eklendi",
                    Message = $"{entity.Name} isimli category eklendi",
                    AlertType = AlertTypeEnum.Success
                });

                return RedirectToAction("ListCategory");
            }
            return View(model);
        }
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
                Products = entity.ProductCategories.Select(p=>p.Product).ToList()
            };
            return View(model);
        }
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

                entity.Name = model.Name;
                entity.Url = model.Url;

                _categoryService.Update(entity);

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Category Guncellendi",
                    Message = $"{entity.Name} isimli category guncellendi.",
                    AlertType = AlertTypeEnum.Success
                });

                return RedirectToAction("ListCategory");
            }
            return View(model);
        }
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

            return RedirectToAction("ListCategory");
        }
        [HttpPost]
        public IActionResult DeleteFromCategory(int productId, int categoryId)
        {
            _categoryService.DeleteFromCategory(productId, categoryId);
            return Redirect("/admin/categories/"+categoryId);
        }
        #endregion
    }
}
