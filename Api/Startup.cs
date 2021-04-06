using Api.Extensions;
using Autofac;
using Core;
using FluentValidation.AspNetCore;
using Infastructure;
using Infastructure.Data.Mapping;
using Infastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDbContext(Configuration);
            services.RegisterRepositories();
            services.ConfigureIdentity();
            services.ConfigureJwtAuthentication(Configuration);
            services.AddAutoMapper(typeof(DataProfile));
            
            services.ConfigureCors();
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.ConfigureSwagger();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public static void ConfigureContainer(ContainerBuilder container)
        {
            container.RegisterModule(new CoreModule());
            container.RegisterModule(new InfastructureModule());

            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Presenter")).SingleInstance();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(swaggger =>
            {
                swaggger.SwaggerEndpoint("/swagger/v1/swagger.json", "Books Api v1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
