using System;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Foompany.Services.AppFeatures;
using Foompany.Services.SampleService1.AppFeatures;

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
[assembly: EnableAppFeatureFlag<SimulatedLatencyFeature>]
[assembly: EnableAppFeatureFlag<MaxBooksToReturn>]
[assembly: EnableAppFeatureFlag<AllowIPs>]
[assembly: EnableAppFeatureFlag<ExperimentalFeatures>]   // note : this is a shared feature (quantum space scoped)
