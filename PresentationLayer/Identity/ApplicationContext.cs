using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PresentationLayer.Identity
{
    public class ApplicationContext:IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            this.Database.SetCommandTimeout(999999);
        }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
    }
}
