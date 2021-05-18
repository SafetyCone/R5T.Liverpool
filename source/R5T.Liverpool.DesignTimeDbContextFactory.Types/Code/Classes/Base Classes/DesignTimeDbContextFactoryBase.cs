using System;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using R5T.Dacia;
using R5T.Richmond;


namespace R5T.Liverpool.DesignTimeDbContextFactory.Types
{
    public abstract class DesignTimeDbContextFactoryBase<TDbContext, TDesignTimeDbContextFactoryStartup> : IDesignTimeDbContextFactory<TDbContext>
        where TDbContext : DbContext
        where TDesignTimeDbContextFactoryStartup : class, IStartup
    {
        public TDbContext CreateDbContext(string[] args)
        {
            var emptyServiceProvider = ServiceProviderHelper.GetNewEmptyServiceProvider();

            var serviceProvider = ServiceProviderServiceBuilder.New()
                .UseStartup<TDesignTimeDbContextFactoryStartup>()
                .Build(emptyServiceProvider);

            var dbContext = serviceProvider.GetRequiredService<TDbContext>();
            return dbContext;
        }
    }
}
