using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using R5T.Venetia;


namespace R5T.Liverpool.Database.Migrations
{
    public class DatabaseContextOptionsBuilderConfigurator : IDatabaseContextOptionsBuilderConfigurator
    {
        public void ConfigureDatabaseContextOptionsBuilder(DbContextOptionsBuilder dbContextOptionsBuilder, SqlServerDbContextOptionsBuilder sqlServerDbContextOptionsBuilder)
        {
            sqlServerDbContextOptionsBuilder
                .MigrationsAssembly("R5T.Liverpool.Database.Migrations")
                ;
        }
    }
}
