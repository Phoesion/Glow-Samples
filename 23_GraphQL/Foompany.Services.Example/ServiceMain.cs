using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK.Firefly;
using Microsoft.AspNetCore.Builder;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using StarWars;
using System.IO;

namespace Foompany.Services.Example
{
    [ServiceName("Example")]
    public class ServiceMain : FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQL(b => b
                        .AddSystemTextJson()
                        .AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true)
                        .AddSchema<StarWarsSchema>()
                        .AddGraphTypes(typeof(StarWarsSchema).Assembly));

            services.AddSingleton<StarWarsData>();
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            app.AsAspApp()
                .UseGraphQL()
                .UseGraphQLPlayground(options: new GraphQL.Server.Ui.Playground.PlaygroundOptions()
                {
                    GraphQLEndPoint = "/Example/graphql" //need to prefix '/graphql' with the service name
                });
        }
    }
}
