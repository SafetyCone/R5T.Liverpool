using System;

using Microsoft.Extensions.Logging;

using R5T.Liverpool.DesignTimeDbContextFactory.Types;


namespace R5T.Liverpool.Database.Migrations
{
    public class DesignTimeDbContextFactoryStartup : DesignTimeDbContextFactoryStartup<LiverpoolDbContext, ConnectionStringProvider, DatabaseContextOptionsBuilderConfigurator>
    {
        public DesignTimeDbContextFactoryStartup(ILogger<DesignTimeDbContextFactoryStartup> logger)
            : base(logger)
        {
        }
    }
}
