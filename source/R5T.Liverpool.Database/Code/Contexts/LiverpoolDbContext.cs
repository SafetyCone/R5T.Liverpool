using System;

using Microsoft.EntityFrameworkCore;


namespace R5T.Liverpool.Database
{
    public class LiverpoolDbContext : DbContext
    {
        public LiverpoolDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<ExampleEntity> ExampleEntities { get; set; }
    }
}
