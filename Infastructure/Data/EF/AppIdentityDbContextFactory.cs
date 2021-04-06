using Microsoft.EntityFrameworkCore;

namespace Infastructure.Data.EF
{
    public class AppIdentityDbContextFactory : DesignTimeDbContextFactoryBase<ApplicationDbContext>
    {
        protected override ApplicationDbContext CreateNewInstance(DbContextOptions<ApplicationDbContext> options)
        {
            return new ApplicationDbContext(options);
        }
    }
}
