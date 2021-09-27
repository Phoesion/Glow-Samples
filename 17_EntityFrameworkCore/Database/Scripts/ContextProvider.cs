using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Foompany.Services.SampleService1
{
    // We implement IDesignTimeDbContextFactory to allow EFCore design tools to create our dbContext and allow us to perform 'update-database', 'add-migration' and so on.

    public class ContextProvider : IDesignTimeDbContextFactory<dbSchemaContext>
    {
        public dbSchemaContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<dbSchemaContext>();
            builder.UseMySql(args[0], ServerVersion.AutoDetect(args[0]),
                             o => o.MigrationsAssembly(typeof(ContextProvider).Assembly.FullName));
            return new dbSchemaContext(builder.Options);
        }
    }
}
