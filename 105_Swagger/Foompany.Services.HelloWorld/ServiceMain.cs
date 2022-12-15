using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using System.IO;
using System.Reflection;

namespace Foompany.Services.HelloWorld
{
    [ServiceName("HelloWorld")]
    public class ServiceMain : FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            // Register the Swagger generator
            services.AddSwaggerGen(options =>
            {
                //full name schemas (to avoid conflicts)
                options.CustomSchemaIds(x => x.FullName.Replace("+", "."));

                //use documentation xml
                var xmlFilename = $"{typeof(ServiceMain).Assembly.GetName().Name}.xml";
                options.IncludeXmlComments(xmlFilename);
            });
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            //Swagger middleware
            //IMPORTANT: we also need to add a [DynamicRoutingRule] in our AssemblyInfo.cs to register the "/swagger/.." route
            app.AsAspApp()
                    // Enable middleware to serve generated Swagger as a JSON endpoint.
                    .UseSwagger()
                    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
                    .UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/HelloWorld/swagger/v1/swagger.json", "My API V1");
                    });
        }
    }
}
