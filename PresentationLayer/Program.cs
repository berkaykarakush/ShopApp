using AspNetCoreHero.ToastNotification.Extensions;
using BusinessLayer;
using BusinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Concrete.EFCore;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using PresentationLayer.Extensions;
using PresentationLayer.Identity;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Configuration.ConnectionString(builder.Configuration);//this method for appsettings.json and secret.json
builder.Services.AddControllersWithViews();
builder.Services.AddDataAccessLayerServices();
builder.Services.AddBusinessLayerServices();
builder.Services.AddPresentationLayerServices();

//CORS Policy
builder.Services.AddCors(options => 
   options.AddPolicy("myclients", builder =>
   builder.WithOrigins("https://localhost:7087","http://localhost:7087").AllowAnyMethod().AllowAnyOrigin()));

//Serilog Configuration
Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.MSSqlServer(Configuration._configuration.GetSection("ConnectionStrings:MsSQLConnection").Value, sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true }, null, null, LogEventLevel.Information, null, columnOptions: null, null, null)
        .WriteTo.Seq(Configuration._configuration.GetSection("Seq:ServerURL").Value)
        .CreateLogger();

//Serilog
builder.Host.UseSerilog();

//Default log - Bulit in
builder.Services.AddLogging();

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.RequestBodyLogLimit = 4096;
});

//builder.WebHost.CaptureStartupErrors(true);
//builder.WebHost.UseSetting("detailedErrors","true");

try
{
    Log.Information("Starting web application");
    var app = builder.Build();
    app.UseSerilogRequestLogging();
    app.UseHttpLogging();
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

    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor |
        ForwardedHeaders.XForwardedProto
    });
    //Custom Extensions
    app.UseConfigureExceptionHandler();

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    //CORS Policy
    app.UseCors("myclients");

    app.UseAuthentication();

    app.UseAuthorization();

    //Toast Notification
    app.UseNotyf();

    //Error Page
    app.UseStatusCodePagesWithReExecute("/Error", "?statusCode={0}");

    #region Brand Route
    app.MapControllerRoute(
       name: "adminBrands",
       pattern: "admin/brand/list",
       defaults: new { controller = "Brand", action = "ListBrand" });

    app.MapControllerRoute(
       name: "adminCreateBrand",
       pattern: "admin/brand/create",
       defaults: new { controller = "Brand", action = "CreateBrand" });

    app.MapControllerRoute(
      name: "adminUpdateBrand",
      pattern: "admin/brand/{id?}",
      defaults: new { controller = "Brand", action = "UpdateBrand" });
    #endregion

    #region Admin Route
    app.MapControllerRoute(
        name: "adminPanel",
        pattern: "admin",
        defaults: new { controller = "Admin", action = "Dashboard" });
    #endregion

    #region Order Route
    app.MapControllerRoute(
        name: "orders",
        pattern: "orders",
        defaults: new { controller = "Order", action = "GetOrders" });
    #endregion

    #region Cart Route
    app.MapControllerRoute(
        name: "checkout",
        pattern: "checkout",
        defaults: new { controller = "Cart", action = "Checkout" });

    app.MapControllerRoute(
        name: "cart",
        pattern: "cart",
        defaults: new { controller = "Cart", action = "Index" });
    #endregion

    #region Campaign Route
    app.MapControllerRoute(
       name: "adminCampaigns",
       pattern: "admin/campaign/list",
       defaults: new { controller = "Campaign", action = "ListCampaign" });

    app.MapControllerRoute(
       name: "adminCampaignCreate",
       pattern: "admin/campaign/create",
       defaults: new { controller = "Campaign", action = "CreateCampaign" });

    app.MapControllerRoute(
      name: "adminEditCampaign",
      pattern: "admin/campaign/{id?}",
      defaults: new { controller = "Campaign", action = "EditCampaign" });
    #endregion

    #region User Route
    app.MapControllerRoute(
        name: "adminUsers",
        pattern: "admin/user/list",
        defaults: new { controller = "User", action = "ListUser" });

    app.MapControllerRoute(
        name: "adminEditUser",
        pattern: "admin/user/{id?}",
        defaults: new { controller = "User", action = "EditUser" });

    app.MapControllerRoute(
       name: "UpdateUser",
       pattern: "user/updateuser",
       defaults: new { controller = "User", action = "UpdateUser" });
    #endregion

    #region Role Route

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
    #endregion

    #region Product Route

    app.MapControllerRoute(
        name: "adminProducts",
        pattern: "admin/product/list",
        defaults: new { controller = "Product", action = "ListProduct" });

    app.MapControllerRoute(
        name: "adminCreateProduct",
        pattern: "admin/product/create",
        defaults: new { controller = "Product", action = "CreateProduct" });

    app.MapControllerRoute(
        name: "adminEditProduct",
        pattern: "admin/product/{id?}",
        defaults: new { controller = "Product", action = "EditProduct" });
    #endregion


    #region Category Route
    app.MapControllerRoute(
        name: "adminCategories",
        pattern: "admin/category/list",
        defaults: new { controller = "Category", action = "ListCategory" });

    app.MapControllerRoute(
        name: "adminCreateCategory",
        pattern: "admin/category/create",
        defaults: new { controller = "Category", action = "CreateCategory" });


    app.MapControllerRoute(
        name: "adminEditCategory",
        pattern: "admin/category/{id?}",
        defaults: new { controller = "Category", action = "EditCategory" });
    #endregion

    #region Category2 Route
    app.MapControllerRoute(
        name: "adminCategory2",
        pattern: "admin/category2/list",
        defaults: new { controller = "Category2", action = "ListCategory2" });

    app.MapControllerRoute(
        name: "adminCreateCategory2",
        pattern: "admin/category2/create",
        defaults: new { controller = "Category2", action = "CreateCategory2" });


    app.MapControllerRoute(
        name: "adminEditCategory2",
        pattern: "admin/category2/{category2Id?}",
        defaults: new { controller = "Category2", action = "EditCategory2" });
    #endregion

    //category2 route
    app.MapControllerRoute(
       name: "productsbrand",
       pattern: "b/{brand?}",
       defaults: new { controller = "Shop", action = "BrandList" });

    //category2 route
    app.MapControllerRoute(
       name: "products2",
       pattern: "c/2/{category2?}",
       defaults: new { controller = "Shop", action = "Category2List" });

    //categort route
    app.MapControllerRoute(
        name: "products",
        pattern: "c/{category?}",
        defaults: new { controller = "Shop", action = "CategoryList" });

    app.MapControllerRoute(
        name: "productsDetails",
        pattern: "{url}",
        defaults: new { controller = "Shop", action = "CategoryList" });

    app.MapControllerRoute(
        name: "search",
        pattern: "search",
        defaults: new { controller = "Shop", action = "Search" });

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly!");
}
finally
{
    Log.CloseAndFlush();
}