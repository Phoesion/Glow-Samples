using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.AppFeatures
{
    [AppFeatureFlagInt(
        "Latest Books To Return", // UI Title
        4,  // Default value
        1, 10, //Min-Max
        Description = "How many results to return from the 'Library.Books/List' endpoint" // UI Description
    )]
    public class MaxBooksToReturn : AppFeatureFlagInt
    {
    }
}
