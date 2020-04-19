using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.DistributedMemoryCache;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Threading.Tasks;

namespace Foompany.Services.DistributedMemoryCache
{
    [ServiceName("DistributedMemoryCache")]
    public class ServiceMain : Phoesion.Glow.SDK.Firefly.FireflyService
    {
    }
}
