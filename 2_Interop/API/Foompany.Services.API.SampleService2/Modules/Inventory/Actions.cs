using System;
using System.Collections.Generic;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System.Linq;
using System.Threading.Tasks;

namespace Foompany.Services.API.SampleService2.Modules.Inventory
{
    public static class Actions
    {
        [Action(Methods.GET), Interop]
        public static IEnumerable<Models.Book> GetBooks() => default;

        [Action(Methods.GET), Interop]
        public static IQueryable<Models.Book> GetBooksFromDB() => default;
    }
}
