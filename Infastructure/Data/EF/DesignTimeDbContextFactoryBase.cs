using Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Infastructure.Data.EF
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext>
        where  TContext : DbContext
    {
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        public TContext CreateDbContext(string[] args)
        {
            return Create();
        }

        private TContext Create()
        {
            var build = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            string connectionString = build.GetConnectionString("Default");
            if (connectionString.IsNullOrEmptyOrWhiteSpace())
            {
                throw new InvalidOperationException("No connectionString named 'Default' was found");
            }

            var optionsBuilder = new DbContextOptionsBuilder<TContext>()
                .UseSqlServer(connectionString);

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}
