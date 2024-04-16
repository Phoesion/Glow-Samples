using System;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Foompany.Services.AppFeatures;
using Foompany.Services.SampleService2.AppFeatures;

//---------------------------------------------------
//   Cross-Origin Resource Sharing (CORS) Setup
//---------------------------------------------------
// Define CORS schemes to be used in service/assembly
[assembly: CORS_Policy("Default")]
//[assembly: CORS_Policy("MyScheme", Origins = new[] { "https://*.mydomain.com" })]
//[assembly: CORS_Policy("MySchemeWithMacro", Origins = new[] { "https://*.${qsdomain}" })]  //${qsdomain} is a macro that will be replaced with all binded domains of the quantum space

// Uncomment to enable 'Default' scheme for this service (can also be applied per-module or per-action)
//[assembly: EnableCORS("Default")]


//---------------------------------------------------
//   Enable my custom App Features
//---------------------------------------------------
[assembly: EnableAppFeatureFlag<ExperimentalFeatures>]   // note : this is a shared feature (quantum space scoped)
[assembly: EnableAppFeatureFlag<ProfileSampleModule1Feature>]
[assembly: EnableAppFeatureFlag<ProfileSampleModule2Feature>]
[assembly: EnableAppFeatureFlag<ProfileSampleModule3Feature>]
[assembly: EnableAppFeatureFlag<SampleStringFeature>]
[assembly: EnableAppFeatureFlag<ABTestingFeature>]


//---------------------------------------------------
//   Enable build-in Module Version Selector feature-flags
//---------------------------------------------------
// Allows fro dynamically changing default version for modules from Blaze GUI
[assembly: AppFeatureFlagModuleVersionSelector<Foompany.Services.SampleService2.Modules.VersionedModule.v2>]

