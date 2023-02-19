using System;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


// Run middleware for statics files in the "Content\Protected\.." directory
[assembly: RunMiddlewareForStaticFiles("Content/Protected/*")]
[assembly: StaticFileCacheControl("Content/Protected/*", "private")] // also mark protected files with 'private' cache-control value

// Sample : Add custom headers to static files
[assembly: StaticFileHeader("Content/*", "x-header-key", "myValue")]

// custom cache-control header value for static files
[assembly: StaticFileCacheControl("wwwroot/AnotherTextFile.txt", "public, max-age=120")]
