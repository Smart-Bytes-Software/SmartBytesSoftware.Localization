using Microsoft.Extensions.DependencyInjection;
using SmartBytesSoftware.Localization.Abstractions;
using SmartBytesSoftware.Localization.Abstractions.Providers;

namespace SmartBytesSoftware.Localization.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterLocalizer(this IServiceCollection services)
        {
            services.AddTransient(serviceProvider =>
            {
                ILocalizationResourceProvider provider = serviceProvider.GetService<ILocalizationResourceProvider>();
                ILocalizer localizer = provider.Create();
                return localizer;
            });
        }
    }
}
