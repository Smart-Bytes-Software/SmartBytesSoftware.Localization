using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Options;
using SmartBytesSoftware.Localization.Abstraction.Options;
using SmartBytesSoftware.Localization.Exceptions;
using SmartBytesSoftware.Localization.Models;

namespace SmartBytesSoftware.Localization.Providers
{
    public abstract class LocalizationResourceProviderBase
    {
        private readonly IOptions<ILocalizationOptions> options;
        protected ConcurrentDictionary<string, LocalizedResourceDictionary> localizedResourcesCache =
            new ConcurrentDictionary<string, LocalizedResourceDictionary>();

        public LocalizationResourceProviderBase(IOptions<ILocalizationOptions> options)
        {
            this.options = options;
        }

        protected virtual string ReadResourceFile(string fileExtension)
        {
            string cultureName = CultureInfo.CurrentCulture.Name;
            string resources;

            try
            {
                string cultureNameExtension = $".{cultureName}";
                resources = ReadResourceFileSafe(cultureNameExtension, fileExtension);
            }
            catch (Exception ex) when (ex is FileNotFoundException fileNotFoundException)
            {
                // If not culture-specific resource file exists, fallback to the default resource file.
                try
                {
                    resources = ReadResourceFileSafe(cultureNameExtension: string.Empty, fileExtension: fileExtension);
                }
                catch (Exception)
                {
                    throw new ResourceNotFoundException($"`{options.Value.ResourceName}{fileExtension}` resource file does not exist");
                }
            }

            if (!string.IsNullOrWhiteSpace(resources))
            {
                IEnumerable<LocalizedResource> localizedResources = InitializeResources(resources);
                CacheResources(cultureName, localizedResources);
            }

            return resources;
        }
        protected abstract IEnumerable<LocalizedResource> InitializeResources(string resources);

        protected void CacheResources(string cultureName, IEnumerable<LocalizedResource> localizedResources)
        {
            var cultureSpecificResourcesCache = new LocalizedResourceDictionary();

            localizedResources
                .ToList()
                .ForEach(localizedResource => cultureSpecificResourcesCache.TryAdd(localizedResource.Name, localizedResource.Value));

            localizedResourcesCache.TryAdd(cultureName, cultureSpecificResourcesCache);
        }

        private string ReadResourceFileSafe(string cultureNameExtension, string fileExtension)
        {
            string basePath = AppContext.BaseDirectory;
            string resourceFileName = $"{options.Value.ResourceName}{cultureNameExtension}{fileExtension}";
            string resourcePath = Path.Combine(basePath, options.Value.ResourcesPath, resourceFileName);

            using StreamReader streamReader = File.OpenText(resourcePath);

            return streamReader.ReadToEnd();
        }
    }
}
