using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService2.AppFeatures
{
    [AppFeatureFlagString("Sample String feature", "some_default_value")]
    public class SampleStringFeature : AppFeatureFlagString
    {
    }
}
