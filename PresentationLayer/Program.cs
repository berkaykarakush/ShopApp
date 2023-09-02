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

    //areas
    app.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Dashboard}/{id?}"
    );


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

    //app.MapControllerRoute(
    //  name: "adminUpdateBrand",
    //  pattern: "admin/brand/{id?}",
    //  defaults: new { controller = "Brand", action = "UpdateBrand" });

    //app.MapControllerRoute(
    //  name: "adminEditCampaign",
    //  pattern: "admin/campaign/{id?}",
    //  defaults: new { controller = "Campaign", action = "EditCampaign" });

    //app.MapControllerRoute(
    //    name: "adminEditUser",
    //    pattern: "admin/user/{id?}",
    //    defaults: new { controller = "User", action = "EditUser" });

    //app.MapControllerRoute(
    //    name: "adminEditRole",
    //    pattern: "admin/role/{id?}",
    //    defaults: new { controller = "Role", action = "EditRole" });

    //app.MapControllerRoute(
    //    name: "adminEditProduct",
    //    pattern: "admin/product/{id?}",
    //    defaults: new { controller = "Product", action = "EditProduct" });

    //app.MapControllerRoute(
    //    name: "adminEditCategory",
    //    pattern: "admin/category/{id?}",
    //    defaults: new { controller = "Category", action = "EditCategory" });

    //app.MapControllerRoute(
    //    name: "adminEditCategory2",
    //    pattern: "admin/category2/{category2Id?}",
    //    defaults: new { controller = "Category2", action = "EditCategory2" });

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