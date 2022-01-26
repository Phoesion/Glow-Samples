using System;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

//---------------------------------------------------
//   Cross-Origin Resource Sharing (CORS) Setup
//---------------------------------------------------
// Define CORS schemes to be used in service/assembly
[assembly: CORS_Policy("Default")]
//[assembly: CORS_Policy("MyScheme", Origins = new[] { "https://*.mydomain.com" })]
//[assembly: CORS_Policy("MySchemeWithMacro", Origins = new[] { "https://*.${qsdomain}" })]  //${qsdomain} is a macro that will be replace with all binded domains of the quantum space

// Uncomment to enable 'Default' scheme for this service (can also be applied per-module or per-action)
//[assembly: EnableCORS("Default")]

// Enable Client-side logging for all service actions
//[assembly: EnableClientLogging()]
