using DataAccessLayer.Concrete.EFCore;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Identity;

namespace PresentationLayer.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var applicationContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>())
                {
                    try
                    {
                        applicationContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        //TODO Loglama
                        Console.Write(ex.InnerException.Message.ToString());
                    }
                }
                using (var shopContext = scope.ServiceProvider.GetRequiredService<ShopContext>())
                {
                    try
                    {
                        shopContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        //TODO loglama
                        throw;
                    }
                }
            }
            return host;
        }
    }
}
