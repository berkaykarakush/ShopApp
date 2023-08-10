using BusinessLayer;
using BusinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Concrete.EFCore;
using Microsoft.AspNetCore.Identity;
using PresentationLayer.Identity;
using PresentationLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Configuration.ConnectionString(builder.Configuration);//this method for appsettings.json and secret.json
builder.Services.AddControllersWithViews();
builder.Services.AddDataAccessLayerServices();
builder.Services.AddBusinessLayerServices();
builder.Services.AddPresentationLayerServices();

//builder.WebHost.CaptureStartupErrors(true);
//builder.WebHost.UseSetting("detailedErrors","true");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var host = scope.ServiceProvider.GetService<IHost>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var cartService = scope.ServiceProvider.GetRequiredService<ICartService>();
    MigrationManager.MigrateDatabase(host);
    SeedIdentity.Seed(userManager, roleManager, cartService).Wait();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();  
app.UseAuthorization();

app.MapControllerRoute(
    name: "orders",
    pattern: "orders",
    defaults: new { controller = "Order", action = "GetOrders" });

app.MapControllerRoute(
    name: "checkout",
    pattern: "checkout",
    defaults: new { controller = "Cart", action = "Checkout" });

app.MapControllerRoute(
    name: "cart",
    pattern: "cart",
    defaults: new { controller = "Cart", action = "Index" });

app.MapControllerRoute(
    name: "adminUsers",
    pattern: "admin/user/list",
    defaults: new { controller = "User", action = "ListUser" });

app.MapControllerRoute(
    name: "adminEditUser",
    pattern: "admin/user/{id?}",
    defaults: new { controller = "User", action = "EditUser" });

app.MapControllerRoute(
    name: "adminRoles",
    pattern: "admin/role/list",
    defaults: new { controller = "Role", action = "ListRole" });

app.MapControllerRoute(
    name: "adminRoleCreate",
    pattern: "admin/role/create",
    defaults: new { controller = "Role", action = "CreateRole" });

app.MapControllerRoute(
    name: "adminEditRole",
    pattern: "admin/role/{id?}",
    defaults: new { controller = "Role", action = "EditRole" });

app.MapControllerRoute(
    name: "adminProducts",
    pattern: "admin/products",
    defaults: new { controller = "Product", action = "ListProduct" });

app.MapControllerRoute(
    name: "adminCategories",
    pattern: "admin/categories",
    defaults: new { controller = "Category", action = "ListCategory" });

app.MapControllerRoute(
    name: "adminCreateProduct",
    pattern: "admin/product/create",
    defaults: new { controller = "Product", action = "CreateProduct" });

app.MapControllerRoute(
    name: "adminCreateCategory",
    pattern: "admin/category/create",
    defaults: new { controller = "Category", action = "CreateCategory" });

app.MapControllerRoute(
    name: "adminEditProduct",
    pattern: "admin/products/{id?}",
    defaults: new { controller = "Product", action = "EditProduct" });

app.MapControllerRoute(
    name: "adminEditCategory",
    pattern: "admin/categories/{id?}",
    defaults: new { controller = "Category", action = "EditCategory" });

app.MapControllerRoute(
    name: "search",
    pattern: "search",
    defaults: new { controller = "Shop", action = "Search" });

app.MapControllerRoute(
    name: "productsDetails",
    pattern: "{url}",
    defaults: new { controller = "Shop", action = "List" });

app.MapControllerRoute(
    name: "products",
    pattern: "products/{category?}",
    defaults: new {controller="Shop", action="List"});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
