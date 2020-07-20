using System;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Foompany.Services.SampleService1.Modules;

//---------------------------------------------------
//   Cross-Origin Resource Sharing (CORS) Setup
//---------------------------------------------------
// Define CORS schemes to be used in service/assembly
[assembly: CORS_Policy("Default")]
//[assembly: CORS_Policy("MyScheme", Origins = new[] { "https://*.mydomain.com" })]
//[assembly: CORS_Policy("MySchemeWithMacro", Origins = new[] { "https://*.${qsdomain}" })]  //${qsdomain} is a macro that will be replace with all binded domains of the quantum space

// Uncomment to enable 'Default' scheme for this service (can also be applied per-module or per-action)
//[assembly: EnableCORS("Default")]


//---------------------------------------------------
//   Url Rewrites 
//---------------------------------------------------
//Define the rules that the service will request for Url rewrites in its quantum space
[assembly: UrlRewriteRule("/someRandom/pathToHit", "/" + nameof(SampleModule1) + "/" + nameof(SampleModule1.Action1))]
//Important : the 'To' rule will be prefixed with the service name. So in the above sample the final target url will be "/SampleService1/SampleModule1/Action1"