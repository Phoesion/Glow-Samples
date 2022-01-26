using System;
using System.Collections.Generic;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Microsoft.AspNetCore.OData.Query;
using System.Linq;
using System.Threading.Tasks;

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
        public IEnumerable<Models.Book> GetBooks()
        {
            /*
             * You can perform filters on this results using eg :
             * http://localhost:16000/BookStore/Inventory/GetBooks?$select=Title&$orderby=Id%20desc
             * or
             * http://localhost:16000/BookStore/Inventory/GetBooks?$filter=id%20eq%201&$select=Title
            */
            yield return new Models.Book() { Id = 0, Title = "book 0", Price = 2m };
            yield return new Models.Book() { Id = 1, Title = "book 1", Price = 3.5m };
            yield return new Models.Book() { Id = 2, Title = "book 2", Price = 7.4m };
            yield return new Models.Book() { Id = 3, Title = "book 3", Price = 6.2m };
            yield return new Models.Book() { Id = 4, Title = "book 4", Price = 3.8m };
            yield return new Models.Book() { Id = 5, Title = "book 5", Price = 12.23m };
            yield return new Models.Book() { Id = 6, Title = "book 6", Price = 12m };
            yield return new Models.Book() { Id = 7, Title = "book 7", Price = 32.2m };
            yield return new Models.Book() { Id = 8, Title = "book 8", Price = 4.99m };
            yield return new Models.Book() { Id = 9, Title = "book 9", Price = 13.1m };
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        [EnableQuery]       // <-- Enable OData functionality
        public IEnumerable<Models.Book> GetBooksFromDB()
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
    }
}
