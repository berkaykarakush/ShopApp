using BusinessLayer;
using BusinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Concrete.EFCore;
using DataAccessLayer.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using PresentationLayer.Extensions;
using PresentationLayer.Identity;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Sinks.MSSqlServer;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Configuration.ConnectionString(builder.Configuration);//this method for appsettings.json and secret.json
builder.Services.AddControllersWithViews();
builder.Services.AddDataAccessLayerServices();
builder.Services.AddBusinessLayerServices();
builder.Services.AddPresentationLayerServices();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateProductCommandHandler).GetTypeInfo().Assembly));
builder.Services.AddSerilog(logger: Log.Logger);


var logDB = Configuration._configuration.GetSection("ConnectionStrings:MsSQLConnection").Value;
var sinkOpts = new MSSqlServerSinkOptions();
sinkOpts.TableName = "Logs";
sinkOpts.SchemaName = "dbo";
sinkOpts.AutoCreateSqlTable = true;
sinkOpts.AutoCreateSqlDatabase = true;
var columnOpts = new ColumnOptions();
columnOpts.Store.Add(StandardColumn.LogEvent);
columnOpts.LogEvent.DataLength = 2048;
columnOpts.TimeStamp.NonClusteredIndex = true;

var log = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File(new CompactJsonFormatter(), "Log.json", rollingInterval: RollingInterval.Day)
    .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
    .WriteTo.MSSqlServer(
            connectionString: logDB,
            sinkOptions: sinkOpts,
            columnOptions: columnOpts,
            restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
     )
    .WriteTo.Seq(Configuration._configuration.GetSection("Seq:ServerURL").Value)
    .CreateLogger();

builder.Host.UseSerilog(log);
//builder.Services.AddLogging();

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
    log.Information("Starting web application");
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

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseAuthentication();
    app.UseRouting();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "adminPanel",
        pattern: "admin/index",
        defaults: new { controller = "Admin", action = "Index" });

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
        defaults: new { controller = "Shop", action = "List" });

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();

}
catch (Exception ex)
{
    log.Fatal(ex, "Application terminated unexpectedly!");
}
finally
{
    log.Dispose();
}