using BusinessLayer;
using DataAccessLayer;
using DataAccessLayer.Concrete.EFCore;
using PresentationLayer.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Configuration.ConnectionString(builder.Configuration);//this method for appsettings.json and secret.json
builder.Services.AddControllersWithViews();
builder.Services.AddDataAccessLayerServices();
builder.Services.AddBusinessLayerServices();
builder.Services.AddPresentationLayerServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
SeedData.Seed();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();  
app.UseAuthorization();

app.MapControllerRoute(
    name: "adminProducts",
    pattern: "admin/products",
    defaults: new { controller = "Admin", action = "ListProduct" });

app.MapControllerRoute(
    name: "adminCategories",
    pattern: "admin/categories",
    defaults: new { controller = "Admin", action = "ListCategory" });

app.MapControllerRoute(
    name: "adminCreateProduct",
    pattern: "admin/product/create",
    defaults: new { controller = "Admin", action = "CreateProduct" });

app.MapControllerRoute(
    name: "adminCreateCategory",
    pattern: "admin/category/create",
    defaults: new { controller = "Admin", action = "CreateCategory" });

app.MapControllerRoute(
    name: "adminEditProduct",
    pattern: "admin/products/{id?}",
    defaults: new { controller = "Admin", action = "EditProduct" });

app.MapControllerRoute(
    name: "adminEditCategory",
    pattern: "admin/categories/{id?}",
    defaults: new { controller = "Admin", action = "EditCategory" });

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
