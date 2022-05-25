using System;
using System.Collections.Generic;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.Linq;
using System.Threading.Tasks;

using inventoryApi = Foompany.Services.API.SampleService2;

namespace Foompany.Services.SampleService1.Modules
{
    public class InteropDataFilterSample : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Module up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<IEnumerable<inventoryApi.Models.Book>> GetBooks()
        {
            //invoke the bookstore service GetBooks() with data filtering (that will be applied at the remote machine)
            var books = await Call(inventoryApi.Modules.Inventory.Actions.GetBooks)
                                .WithDataFilter(x => x.Where(x => x.Price > 5)
                                                      .OrderBy(v => v.Id)
                                                      .Skip(1)
                                                      .Take(3))
                                .InvokeAsync();

            return books;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<IEnumerable<inventoryApi.Models.Book>> GetBooksFromDB()
        {
            //invoke the bookstore service GetBooksFromDB() with data filtering (that will be applied at the remote machine)
            var books = await Call(inventoryApi.Modules.Inventory.Actions.GetBooksFromDB)
                                .WithDataFilter(x => x.Where(v => v.Title.Contains("another"))
                                                      .Skip(1)
                                                      .Take(2))
                                .InvokeAsync();
            return books;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
