/* This will be a Static File Service, meaning it will only serve static file and will not execute any code on a firefly.
 * We use the AssemblyInfo.cs to configure service parameters on assembly-level
 */
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

// The Service's name
[assembly: ServiceName("UI.BlazorApp")]

// This will be a static file service!
[assembly: IsStaticFileService]

// Fallback to serving index.html when requesting a missing resource ( with 200 OK code )
[assembly: ResourceNotFoundFallbackPolicy("wwwroot/index.html", HttpStatusCode.OK)]
