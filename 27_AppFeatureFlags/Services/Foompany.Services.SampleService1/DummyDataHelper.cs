using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foompany.Services.SampleService1.Dtos;

namespace Foompany.Services.SampleService1
{
    //Helper to generate dummy data for demonstration purposes
    static class DummyDataHelper
    {
        public static IEnumerable<Book> GetBooks()
        {
            var baseDate = new DateTime(2020, 1, 1);

            yield return new Book() { Title = "db book 0", Price = 2m, DatePublished = baseDate + TimeSpan.FromDays(1), Location = new Address() { City = "Bannmouth", Street = "3755 Lowes Alley" } };
            yield return new Book() { Title = "db book 1", Price = 3.5m, DatePublished = baseDate + TimeSpan.FromDays(10), Location = new Address() { City = "Holtsford", Street = "36 Sun Valley Road" } };
            yield return new Book() { Title = "db book 2", Price = 7.4m, DatePublished = baseDate + TimeSpan.FromDays(2), Location = new Address() { City = "West Seabrough", Street = "1602 Duncan Avenue" } };
            yield return new Book() { Title = "db book 3", Price = 6.2m, DatePublished = baseDate + TimeSpan.FromDays(200), Location = new Address() { City = "Norpool", Street = "17 Dancing Dove Lane" } };
            yield return new Book() { Title = "db book 4", Price = 3.8m, DatePublished = baseDate + TimeSpan.FromDays(156), Location = new Address() { City = "Eastside", Street = "1148 Pearl Street" } };
            yield return new Book() { Title = "db book 5", Price = 12.23m, DatePublished = baseDate + TimeSpan.FromDays(120), Location = new Address() { City = "Starcaster", Street = "4 Bond Street" } };
            yield return new Book() { Title = "db book 6", Price = 12m, DatePublished = baseDate + TimeSpan.FromDays(53), Location = new Address() { City = "Greenkarta", Street = "88 Ben Street" } };
            yield return new Book() { Title = "db book 7", Price = 32.2m, DatePublished = baseDate + TimeSpan.FromDays(111), Location = new Address() { City = "Westburgh", Street = "48 Todds Lane" } };
            yield return new Book() { Title = "db book 8", Price = 4.99m, DatePublished = baseDate + TimeSpan.FromDays(136), Location = new Address() { City = "Norkarta", Street = "315 Harper S" } };
            yield return new Book() { Title = "db book 9", Price = 13.1m, DatePublished = baseDate + TimeSpan.FromDays(70), Location = new Address() { City = "Holtspool", Street = "22 Pine Street" } };
        }
    }
}
