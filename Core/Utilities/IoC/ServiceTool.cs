using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static TService GetService<TService>() => ServiceProvider.GetService<TService>();
        private static IServiceProvider ServiceProvider { get; set; }
        public static void Create(IServiceCollection services) => ServiceProvider = services.BuildServiceProvider();
    }
}
