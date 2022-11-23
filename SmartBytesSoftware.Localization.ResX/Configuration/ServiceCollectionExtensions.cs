using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using SmartBytesSoftware.Localization.Abstractions.Providers;
using SmartBytesSoftware.Localization.Configuration;
using SmartBytesSoftware.Localization.Resx.Options;

namespace SmartBytesSoftware.Localization.Resx.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddResxLocalizationProvider(this IServiceCollection services)
        {
            services.AddSingleton<ILocalizationResourceProvider, ResxLocalizationProvider>();
            services.RegisterLocalizer();

            services.AddOptions<ResxLocalizationOptions>();
            services.AddOptions<LocalizationOptions>();
        }

        public static void AddResxLocalizationProvider(this IServiceCollection services, Action<ResxLocalizationOptions> configureOptions)
        {
            AddResxLocalizationProvider(services);
            services.Configure(configureOptions);
        }
    }
}
