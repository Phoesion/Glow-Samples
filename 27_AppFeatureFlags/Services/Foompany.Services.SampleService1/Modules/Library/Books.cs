using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foompany.Services.AppFeatures;
using Foompany.Services.SampleService1.Dtos;

namespace Foompany.Services.SampleService1.Modules.Library
{
    public class Books : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        [Autowire]
        IAppFeatureFlagsService appFeatureFlagsService;

        // NOTE: you can also Autowire the specific AppFeature itself like so :
        // [Autowire]
        // AppFeatures.MaxBooksToReturn maxBooksToReturnFeature;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// List the latests publish books.
        /// The number of results to return is determined from 'MaxBooksToReturn' feature value,
        ///   that can be modified from Blaze UI and will be update dynamically without restarting the service
        /// </summary>

        [Action(Methods.GET)]
        public async Task<List<Book>> ListLatest()
        {
            //get item count to return
            var feature_count = await appFeatureFlagsService.Get<AppFeatures.MaxBooksToReturn>()
                                                            .GetValueAsync(Context);

            //perform query and return results
            return DummyDataHelper.GetBooks()
                                  .OrderByDescending(static b => b.DatePublished)
                                  .Take(feature_count)
                                  .ToList();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Some experimental feature that we want to enable/disable dynamically from Blaze UI
        /// </summary>

        [Action(Methods.GET)]
        [AppFeatureFlagGate<ExperimentalFeatures>] //enable endpoint only when 'ExperimentalFeatures' value is 'True'
        public async Task<string> SomeNewFeature()
        {
            return "Experimental feature in SampleService 1 (Library.Books) is enabled!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
