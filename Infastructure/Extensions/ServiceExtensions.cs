using Core.Interfaces.Gateways.Repositories;
using Infastructure.Data.EF;
using Infastructure.Data.Entities;
using Infastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infastructure.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configure Db Context in the container
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="connectionStringName"></param>
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration, string connectionStringName = "Default")
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString(connectionStringName)));

        }
        /// <summary>
        /// Configure Identity
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 7;
                opt.Password.RequireDigit = false;

                opt.User.RequireUniqueEmail = true;

            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();           
        }
        /// <summary>
        /// Register Repositories in a container
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookSubscriptionRepository, BookSubscriptionRepository>();
        }


    }
}
