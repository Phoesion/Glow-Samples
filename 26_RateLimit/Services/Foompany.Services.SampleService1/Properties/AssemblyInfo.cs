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

// Enable Client-side logging for all service actions
//[assembly: EnableClientLogging()]


//---------------------------------------------------
//   Rate-Limiting Policies
//---------------------------------------------------
// Define Fixed-Window Rate-Limit policy
[assembly: FixedWindowRateLimitPolicy("Default", 5, 5, 10)]

// Define Fixed-Window Rate-Limit policy
[assembly: FixedWindowRateLimitPolicy("fixed_window", 5, 1, 1)]

// Define a Concurrency Rate-Limit policy
[assembly: ConcurrencyRateLimitPolicy("concurrency", 2, 10)]

// Define Fixed-Window Rate-Limit policy
[assembly: FixedWindowRateLimitPolicy("fixed_window_per_ip", 5, 1, 1, PartitionKeySources = RateLimitPartitionKeySources.IP)]

// . . . . . . . . .//

// Enable the 'Default' policy for this service (can be overridden from modules or actions)
//[assembly: EnableRateLimit("Default")]

