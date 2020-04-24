using System;

namespace R5T.Liverpool.Database.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nothing here. This is a dummy console project that satisfies the executable project requirement for using the EF Core command-line tools.

            Program.TestDbContextProvision(args);
        }

        /// <summary>
        /// Tests that our infrastructure can provide a DbContext instance.
        /// </summary>
        private static void TestDbContextProvision(string[] args)
        {
            var dbContextFactory = new DbContextFactory();

            var dbContext = dbContextFactory.CreateDbContext(args);
        }
    }
}
