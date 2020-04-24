using System;

using R5T.Lincoln;


namespace R5T.Liverpool.Database.Migrations
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public string GetConnectionString()
        {
            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Liverpool;Trusted_Connection=True;MultipleActiveResultSets=true";
            return connectionString;
        }
    }
}
