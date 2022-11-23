using System;
using Microsoft.Extensions.DependencyInjection;
using SmartBytesSoftware.Localization.Abstractions;
using SmartBytesSoftware.Localization.Abstractions.Providers;
using SmartBytesSoftware.Localization.Configuration;
using SmartBytesSoftware.Localization.Json.Options;

namespace SmartBytesSoftware.Localization.Json.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddJsonLocalizationProvider(this IServiceCollection services)
        {
            services.AddSingleton<ILocalizationResourceProvider, JsonLocalizationResourceProvider>();
            services.RegisterLocalizer();
        }

        public static void AddJsonLocalizationProvider(this IServiceCollection services, Action<JsonLocalizationOptions> configureOptions)
        {
            services.Configure(configureOptions);
            AddJsonLocalizationProvider(services);
        }
    }
}
