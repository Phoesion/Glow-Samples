using System;
using System.Collections.Generic;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Microsoft.AspNetCore.OData.Query;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Foompany.Services.BookStore.Modules
{
    public class Inventory : FireflyModule
    {
        [Autowire]
        MyDBContext dbcontext;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Module up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        [EnableQuery]       // <-- Enable OData functionality
        public IQueryable<Models.Book> GetBooksFromDB()
        {
            /*
             * You can perform filters on this results using eg :
             * http://localhost:16000/BookStore/Inventory/GetBooksFromDB?$select=Title&$orderby=Id%20desc
             * or
             * http://localhost:16000/BookStore/Inventory/GetBooksFromDB?$filter=id%20eq%201&$select=Title
            */

            //return a base query
            return dbcontext.Books.Where(b => b.Id > 1);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        [EnableQuery]       // <-- Enable OData functionality
        public IEnumerable<Models.Book> GetBooks()
        {
            /*
             * You can perform filters on this results using eg :
             * http://localhost:16000/BookStore/Inventory/GetBooks?$select=Title&$orderby=Id%20desc
             * or
             * http://localhost:16000/BookStore/Inventory/GetBooks?$filter=id%20eq%201&$select=Title
            */
            yield return new Models.Book() { Title = "book 0", Price = 2m, Location = new Models.Address() { City = "Bannmouth", Street = "3755 Lowes Alley" } };
            yield return new Models.Book() { Title = "book 1", Price = 3.5m, Location = new Models.Address() { City = "Holtsford", Street = "36 Sun Valley Road" } };
            yield return new Models.Book() { Title = "book 2", Price = 7.4m, Location = new Models.Address() { City = "West Seabrough", Street = "1602 Duncan Avenue" } };
            yield return new Models.Book() { Title = "book 3", Price = 6.2m, Location = new Models.Address() { City = "Norpool", Street = "17 Dancing Dove Lane" } };
            yield return new Models.Book() { Title = "book 4", Price = 3.8m, Location = new Models.Address() { City = "Eastside", Street = "1148 Pearl Street" } };
            yield return new Models.Book() { Title = "book 5", Price = 12.23m, Location = new Models.Address() { City = "Starcaster", Street = "4 Bond Street" } };
            yield return new Models.Book() { Title = "book 6", Price = 12m, Location = new Models.Address() { City = "Greenkarta", Street = "88 Ben Street" } };
            yield return new Models.Book() { Title = "book 7", Price = 32.2m, Location = new Models.Address() { City = "Westburgh", Street = "48 Todds Lane" } };
            yield return new Models.Book() { Title = "book 8", Price = 4.99m, Location = new Models.Address() { City = "Norkarta", Street = "315 Harper S" } };
            yield return new Models.Book() { Title = "book 9", Price = 13.1m, Location = new Models.Address() { City = "Holtspool", Street = "22 Pine Street" } };
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
