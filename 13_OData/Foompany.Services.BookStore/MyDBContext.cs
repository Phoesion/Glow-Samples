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
            context.Books.Add(new Models.Book() { Title = "db book 0", Price = 2m, Location = new Models.Address() { City = "Bannmouth", Street = "3755 Lowes Alley" } });
            context.Books.Add(new Models.Book() { Title = "db book 1", Price = 3.5m, Location = new Models.Address() { City = "Holtsford", Street = "36 Sun Valley Road" } });
            context.Books.Add(new Models.Book() { Title = "db book 2", Price = 7.4m, Location = new Models.Address() { City = "West Seabrough", Street = "1602 Duncan Avenue" } });
            context.Books.Add(new Models.Book() { Title = "db book 3", Price = 6.2m, Location = new Models.Address() { City = "Norpool", Street = "17 Dancing Dove Lane" } });
            context.Books.Add(new Models.Book() { Title = "db book 4", Price = 3.8m, Location = new Models.Address() { City = "Eastside", Street = "1148 Pearl Street" } });
            context.Books.Add(new Models.Book() { Title = "db book 5", Price = 12.23m, Location = new Models.Address() { City = "Starcaster", Street = "4 Bond Street" } });
            context.Books.Add(new Models.Book() { Title = "db book 6", Price = 12m, Location = new Models.Address() { City = "Greenkarta", Street = "88 Ben Street" } });
            context.Books.Add(new Models.Book() { Title = "db book 7", Price = 32.2m, Location = new Models.Address() { City = "Westburgh", Street = "48 Todds Lane" } });
            context.Books.Add(new Models.Book() { Title = "db book 8", Price = 4.99m, Location = new Models.Address() { City = "Norkarta", Street = "315 Harper S" } });
            context.Books.Add(new Models.Book() { Title = "db book 9", Price = 13.1m, Location = new Models.Address() { City = "Holtspool", Street = "22 Pine Street" } });
            context.SaveChanges();
        }
    }
}
