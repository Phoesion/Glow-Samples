using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.AppFeatures
{
    [AppFeatureFlagIPAddress("Allow only specified IPs", "127.0.0.1, 127.0.0.2")]
    public class AllowIPs : AppFeatureFlagIPAddressAllow
    {
    }
}
