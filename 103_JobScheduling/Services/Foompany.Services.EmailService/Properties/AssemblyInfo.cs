using System;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

//---------------------------------------------------
//   Cross-Origin Resource Sharing (CORS) Setup
//---------------------------------------------------
// Define CORS schemes to be used in service/assembly
[assembly: CORS_Scheme("Default")]
//[assembly: CORS_Scheme("MyScheme", Origins = new[] { "https://*.mydomain.com" })]
//[assembly: CORS_Scheme("MySchemeWithMacro", Origins = new[] { "https://*.${qsdomain}" })]  //${qsdomain} is a macro that will be replace with all binded domains of the quantum space

// Uncomment to enable 'Default' scheme for this service (can also be applied per-module or per-action)
//[assembly: Use_CORS("Default")]

//---------------------------------------------------
//   Dynamic routing rules
//---------------------------------------------------
//Add HangFire dashboard routing rule
[assembly: DynamicRoutingRule("/hangfire")]