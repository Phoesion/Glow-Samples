using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
//using Microsoft.AspNetCore.OData.Query;

namespace Foompany.Services.BookStore.Modules
{
    public class Greeter : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "Module up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        //[EnableQuery]
        public IEnumerable<Models.Book> GetBooks()
        {
            yield return new Models.Book() { Id = 0, Title = "book 1" };
            yield return new Models.Book() { Id = 1, Title = "book 2" };
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
