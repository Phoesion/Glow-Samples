using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.AppFeatures
{
    [AppFeatureFlagInt("Book listing (virtual) delay (ms)", 0, Description = "Add artificial delay (in milliseconds) to the response for testing client")]
    public class SimulatedLatencyFeature : AppFeatureFlagInt
    {
    }
}
