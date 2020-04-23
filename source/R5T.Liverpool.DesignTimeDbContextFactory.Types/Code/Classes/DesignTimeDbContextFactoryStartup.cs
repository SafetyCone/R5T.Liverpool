using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;

using R5T.Lincoln;
using R5T.Richmond;
using R5T.Venetia;
using R5T.Venetia.Extensions;


namespace R5T.Liverpool.DesignTimeDbContextFactory.Types
{
    public class DesignTimeDbContextFactoryStartup<TDbContext, TConnectionStringProvider, TDatabaseContextOptionsBuilderConfigurator> : StartupBase
        where TDbContext: DbContext
        where TConnectionStringProvider: class, IConnectionStringProvider
        where TDatabaseContextOptionsBuilderConfigurator: class, IDatabaseContextOptionsBuilderConfigurator
    {
        public DesignTimeDbContextFactoryStartup(ILogger<DesignTimeDbContextFactoryStartup<TDbContext, TConnectionStringProvider, TDatabaseContextOptionsBuilderConfigurator>> logger)
            : base(logger)
        {
        }

        /// <summary>
        /// Adds the database context.
        /// Base method MUST be called!
        /// Base method can be called at any point in the derived method.
        /// </summary>
        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            services.AddDatabaseContext<TDbContext, TConnectionStringProvider, TDatabaseContextOptionsBuilderConfigurator>();
        }
    }


    public class DesignTimeDbContextFactoryStartup<TDbContext, TConnectionStringProvider> : DesignTimeDbContextFactoryStartup<TDbContext, TConnectionStringProvider, DoNothingDatabaseContextOptionsBuilderConfigurator>
       where TDbContext : DbContext
       where TConnectionStringProvider : class, IConnectionStringProvider
    {
        public DesignTimeDbContextFactoryStartup(ILogger<DesignTimeDbContextFactoryStartup<TDbContext, TConnectionStringProvider>> logger) : base(logger)
        {
        }
    }
}
