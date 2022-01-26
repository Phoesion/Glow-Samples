using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Foompany.Services.BookStore
{
    public class MyDBContext : DbContext
    {
        public DbSet<Models.Book> Books { get; set; }
        public DbSet<Models.Address> Adresses { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        { }

        public static void SeedDB(MyDBContext context)
        {
            context.Books.Add(new Models.Book() { Title = "db book 0", Price = 2m });
            context.Books.Add(new Models.Book() { Title = "db book 1", Price = 3.5m });
            context.Books.Add(new Models.Book() { Title = "db book 2", Price = 7.4m });
            context.Books.Add(new Models.Book() { Title = "db book 3", Price = 6.2m });
            context.Books.Add(new Models.Book() { Title = "db book 4", Price = 3.8m });
            context.Books.Add(new Models.Book() { Title = "db book 5", Price = 12.23m });
            context.Books.Add(new Models.Book() { Title = "db book 6", Price = 12m });
            context.Books.Add(new Models.Book() { Title = "db book 7", Price = 32.2m });
            context.Books.Add(new Models.Book() { Title = "db book 8", Price = 4.99m });
            context.Books.Add(new Models.Book() { Title = "db book 9", Price = 13.1m });
            context.SaveChanges();
        }
    }
}
