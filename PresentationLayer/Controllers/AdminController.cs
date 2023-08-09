using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Enums;
using PresentationLayer.Extensions;
using PresentationLayer.Identity;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        public AdminController(IProductService productService, ICategoryService categoryService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _roleManager = roleManager;
            _userManager = userManager;
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
                    Name = NameEditExtensions.NameEdit(model.Name),
                    Url = UrlNameEditExtensions.UrlNameEdit(model.Name),
                    Description = model.Description,
                    Price = model.Price,
                    ImageUrl = model.ImageUrl,
                    IsApproved = true
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

                entity.Name = NameEditExtensions.NameEdit(model.Name);
                entity.Url = UrlNameEditExtensions.UrlNameEdit(model.Name);
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
        #region Role
        [HttpGet]
        public IActionResult ListRole()
        {
            return View(_roleManager.Roles);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Islem Basarili",
                        Message = $"{model.Name} isimli role basariyla olusturuldu.",
                        AlertType = AlertTypeEnum.Success
                    });
                    return RedirectToAction("ListRole","Admin");
                }
                else
                {
                    var erros = result.Errors;
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Islem Basarisiz!",
                        Message = $"{erros}",
                        AlertType = AlertTypeEnum.Danger
                    });
                }
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "Islem Basarisiz!",
                Message = $"Role olusturulamadi. Lutfen tekrar deneyiniz.",
                AlertType = AlertTypeEnum.Danger
            });
            return View(model);
        }

        [HttpGet]
        public  async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<User>();
            var nonMembers = new List<User>();

            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name)?members:nonMembers;
                list.Add(user);
            }

            var model = new RoleDetails()
            { 
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("",error.Description);
                            }
                        }
                    }
                }
                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }

                }
            }
            return Redirect("/admin/role/"+model.RoleId);
        }
        #endregion
        #region User
        [HttpGet]
        public IActionResult ListUser()
        {
            return View(_userManager.Users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(r => r.Name);
                ViewBag.Roles = roles;  
                return View(new UserDetailsModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    SelectedRoles = selectedRoles
                });
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "Islem Basarisiz",
                Message = $"Kullanici bilgileri guncellenirken bir hata ile karsilasildi. Lutfen daha sonra tekrar deneyiniz. ",
                AlertType = AlertTypeEnum.Danger
            });
            return RedirectToAction("ListUser", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserDetailsModel model, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.EmailConfirmed = model.EmailConfirmed;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles = selectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles).ToArray<string>());

                        TempData.Put("message", new AlertMessage()
                        {
                            Title = "Islem Basarili",
                            Message = $"Kullanici bilgileri guncellendi.",
                            AlertType = AlertTypeEnum.Success
                        });
                        return RedirectToAction("ListUser", "Admin");
                    }
                }
                return RedirectToAction("ListUser", "Admin");
            }
            var roles = _roleManager.Roles.Select(r => r.Name);
            ViewBag.Roles = roles;
            return View(model);
        }
        #endregion
    }
}
