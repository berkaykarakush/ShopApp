using DataAccessLayer.Concrete.EFCore;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Identity;
using Serilog;

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
                        Log.Fatal(ex, "Application Context Migrate Database Error");
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
                        Log.Fatal(ex, "Shop Context Migrate Database Error");
                        throw;
                    }
                }
            }
            return host;
        }
    }
}
