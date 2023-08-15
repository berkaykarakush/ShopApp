using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        //[HttpGet]
        //[Authorize(Roles = "Admin")]
        //public IActionResult ListProduct(string category, int page = 1)
        //{
        //    const int pageSize = 100;
        //    var productViewModel = new ProductListViewModel()
        //    {
        //        PageInfo = new PageInfo()
        //        {
        //            CurrentPage = page,
        //            ItemsPerPage = pageSize,
        //            CurrentCategory = category,
        //            TotalItems = _productService.GetCountByCategory(category)
        //        },
        //        Products = _productService.GetProductsByCategory(category, page, pageSize)
        //    };
        //    return View(productViewModel);
        //}

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult ListProduct()
        {
            var productViewModel = new ProductListViewModel()
            {
                Products = _productService.GetAll()
            };
            return View(productViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct(ProductModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product
                {
                    ProductId = model.ProductId,
                    Name = NameEditExtensions.NameEdit(model.Name),
                    Url = UrlNameEditExtensions.UrlNameEdit(model.Name),
                    Description = model.Description,
                    Price = model.Price,
                    CreatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    ImageUrl = model.ImageUrl,
                    Quantity = model.Quantity,
                    ProductCategories = ViewBag.Categories,
                    IsApproved = true
                };
                entity.ImageUrl = await ImageNameEditExtensions.ImageNameEdit(file, UrlNameEditExtensions.UrlNameEdit(model.Name));
                

                if (_productService.Create(entity))
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Islem Basarili",
                        Message = $"{entity.Name} urun eklendi",
                        AlertType = AlertTypeEnum.Success
                    });
                    return RedirectToAction("ListProduct", "Product");
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
        [Authorize(Roles = "Admin")]
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
                Price = entity.Price,
                Quantity = entity.Quantity,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                IsApproved = entity.IsApproved,
                IsHome = entity.IsHome,
                UpdatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                SelectedCategories = entity.ProductCategories.Select(pc => pc.Category).ToList()
            };

            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditProduct(ProductModel model, double[] categoryIds, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = _productService.GetById(model.ProductId);
                if (entity == null)
                {
                    return NotFound();
                }

                entity.Name = NameEditExtensions.NameEdit(model.Name);
                entity.Url = UrlNameEditExtensions.UrlNameEdit(model.Name);
                entity.Price = model.Price;
                entity.Quantity= model.Quantity;
                entity.Description = model.Description;
                entity.IsApproved = model.IsApproved;
                entity.IsHome = model.IsHome;
                entity.UpdatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                entity.ImageUrl = await ImageNameEditExtensions.ImageNameEdit(file, UrlNameEditExtensions.UrlNameEdit(model.Name));

                if (_productService.Update(entity, categoryIds))
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Islem Basarili",
                        Message = $"{entity.Name} isimli urun guncellendi.",
                        AlertType = AlertTypeEnum.Success
                    });
                    return RedirectToAction("ListProduct", "Product");
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

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
            return RedirectToAction("ListProduct", "Product");
        }
    }
}
