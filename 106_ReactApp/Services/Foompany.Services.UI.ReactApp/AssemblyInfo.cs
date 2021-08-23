using System;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

//---------------------------------------------------
//   Static File Service properties
//---------------------------------------------------
[assembly: ServiceName("myApp")]
[assembly: IsStaticFileService]
[assembly: ResourceNotFoundFallbackPolicy("wwwroot/index.html", ResponseCode = HttpStatusCode.OK)]
