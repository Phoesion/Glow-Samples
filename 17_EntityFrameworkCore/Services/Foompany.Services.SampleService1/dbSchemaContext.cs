using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foompany.Services.SampleService1
{
    public class dbSchemaContext : DbContext
    {
        public DbSet<Models.Blog> Blogs { get; set; }
        public DbSet<Models.Post> Posts { get; set; }

        public dbSchemaContext(DbContextOptions options) : base(options) { }
    }
}
