using System;
using System.Collections.Generic;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.Linq;
using System.Threading.Tasks;

using api = Foompany.Services.API.SampleService2;

namespace Foompany.Services.SampleService2.Modules
{
    /*
     * Sample module that returns an IEnumerable<> and an IQueryable<> that can be further filtered by the other services
     */
    [API<api.Modules.Inventory.Actions>]
    public class Inventory : FireflyModule
    {
        [Autowire]
        MyDBContext dbcontext;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Module up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET), InteropBody]
        public IEnumerable<api.Models.Book> GetBooks()
        {
            //return as IEnumerable
            yield return new api.Models.Book() { Id = 0, Title = "book 0", Price = 2m };
            yield return new api.Models.Book() { Id = 1, Title = "book 1", Price = 3.5m };
            yield return new api.Models.Book() { Id = 2, Title = "book 2", Price = 7.4m };
            yield return new api.Models.Book() { Id = 3, Title = "book 3", Price = 6.2m };
            yield return new api.Models.Book() { Id = 4, Title = "book 4", Price = 3.8m };
            yield return new api.Models.Book() { Id = 5, Title = "book 5", Price = 12.23m };
            yield return new api.Models.Book() { Id = 6, Title = "book 6", Price = 12m };
            yield return new api.Models.Book() { Id = 7, Title = "book 7", Price = 32.2m };
            yield return new api.Models.Book() { Id = 8, Title = "book 8", Price = 4.99m };
            yield return new api.Models.Book() { Id = 9, Title = "book 9", Price = 13.1m };
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET), InteropBody]
        public IQueryable<api.Models.Book> GetBooksFromDB()
        {
            //return a base query
            return dbcontext.Books.Where(b => b.Id > 1);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
