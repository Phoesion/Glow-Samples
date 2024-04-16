using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService2.AppFeatures
{
    // Create module-specific profiling switches (same group)

    [AppFeatureFlagBool("SampleModule1", false, Group = "Profile")]
    public class ProfileSampleModule1Feature : AppFeatureFlagBool { }

    [AppFeatureFlagBool("SampleModule2", false, Group = "Profile")]
    public class ProfileSampleModule2Feature : AppFeatureFlagBool { }

    [AppFeatureFlagBool("SampleModule3", false, Group = "Profile")]
    public class ProfileSampleModule3Feature : AppFeatureFlagBool { }
}
