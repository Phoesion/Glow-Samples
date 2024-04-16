using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Foompany.Services.SampleService2.AppFeatures
{
    [AppFeatureFlagPercentage("A/B Testing Percentage", 0)]
    public class ABTestingFeature : AppFeatureFlagPercentage
    {
    }
}
