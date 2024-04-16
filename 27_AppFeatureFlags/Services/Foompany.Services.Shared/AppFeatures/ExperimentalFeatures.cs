using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.AppFeatures
{
    [AppFeatureFlagBool("Experimental features", false,
                    Scope = GlowAppScope.QuantumSpace, // Note: allow this feature to be used from multiple services in the qSpace
                    Description = "Enable experimental features of my cloud application solution.")]
    public class ExperimentalFeatures : AppFeatureFlagBool
    {
    }
}
