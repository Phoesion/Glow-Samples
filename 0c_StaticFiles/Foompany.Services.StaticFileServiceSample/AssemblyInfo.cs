using System;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

//---------------------------------------------------
//   Static File Service properties
//---------------------------------------------------
[assembly: ServiceName("StaticFileServiceSample")] 
[assembly: IsStaticFileService]

//extra attribute that can control the "NotFound" response (eg serve a different file)
//[assembly: ResourceNotFoundFallbackPolicy("wwwroot/index.html", ResponseCode = HttpStatusCode.OK)]

//extra attribute that can add user-defined headers to static files
//[assembly: StaticFileHeader("*", "X-FRAME-OPTIONS", "SAMEORIGIN")]
