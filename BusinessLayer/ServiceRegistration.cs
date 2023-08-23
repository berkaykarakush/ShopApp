using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EFCore;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
    public static class ServiceRegistration
    {
        public static void AddBusinessLayerServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductService, ProductManager>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IOrderService, OrderManager>();
            serviceCollection.AddScoped<ICartService, CartManager>();
            serviceCollection.AddScoped<ICampaignService, CampaignManager>();
            serviceCollection.AddScoped<IEmailSender, EmailSender>(i => new EmailSender
                (
                    Configuration._configuration.GetSection("EmailSender:Host").Value,
                    Configuration._configuration.GetSection("EmailSender:Port").Value,
                    Configuration._configuration.GetSection("EmailSender:EnableSSl").Value,
                    Configuration._configuration.GetSection("EmailSender:Username").Value,
                    Configuration._configuration.GetSection("EmailSender:Password").Value
                )
            );
        }
    }
}
