using System.Reflection;
using System.Resources;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SmartBytesSoftware.Localization.Abstractions;
using SmartBytesSoftware.Localization.Abstractions.Providers;
using SmartBytesSoftware.Localization.Resx.Options;

namespace SmartBytesSoftware.Localization.Resx
{
    public class ResxLocalizationProvider : ResourceManagerStringLocalizerFactory, ILocalizationResourceProvider
    {
        private readonly IOptions<ResxLocalizationOptions> resxLocalizationOptions;
        private readonly ILoggerFactory loggerFactory;
        private readonly IResourceNamesCache resourceNamesCache = new ResourceNamesCache();

        public ResxLocalizationProvider(
            IOptions<ResxLocalizationOptions> resxLocalizationOptions, 
            IOptions<LocalizationOptions> localizationOptions,
            ILoggerFactory loggerFactory) 
            : base(resxLocalizationOptions, loggerFactory)
        {
            this.resxLocalizationOptions = resxLocalizationOptions;
            this.loggerFactory = loggerFactory;
        }

        public ILocalizer Create()
        {
            IStringLocalizer localizer = Create(resxLocalizationOptions.Value.ResourceType);
            return localizer as ResxLocalizer;
        }

        protected override ResourceManagerStringLocalizer CreateResourceManagerStringLocalizer(Assembly assembly, string baseName)
        {
            return new ResxLocalizer(
                new ResourceManager(baseName, assembly),
                assembly,
                baseName,
                resourceNamesCache,
                loggerFactory.CreateLogger<ResourceManagerStringLocalizer>());
        }
    }
}
