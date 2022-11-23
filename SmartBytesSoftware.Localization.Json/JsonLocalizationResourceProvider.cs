using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.Options;
using SmartBytesSoftware.Localization.Abstractions;
using SmartBytesSoftware.Localization.Abstractions.Providers;
using SmartBytesSoftware.Localization.Json.Options;
using SmartBytesSoftware.Localization.Models;
using SmartBytesSoftware.Localization.Providers;

namespace SmartBytesSoftware.Localization.Json
{
    public class JsonLocalizationResourceProvider : LocalizationResourceProviderBase, ILocalizationResourceProvider
    {
        private readonly IOptions<JsonLocalizationOptions> options;

        public JsonLocalizationResourceProvider(IOptions<JsonLocalizationOptions> options)
            : base(options)
        {
            this.options = options;
        }

        public ILocalizer Create()
        {
            string jsonFile = ReadResourceFile(".json");

            return new JsonLocalizer(localizedResourcesCache[CultureInfo.CurrentCulture.Name]);
        }

        protected override string ReadResourceFile(string fileExtension)
        {
            if (options.Value.ResourcePathResolver != null)
            {
                return options.Value.ResourcePathResolver();
            }

            return base.ReadResourceFile(fileExtension);
        }

        protected override IEnumerable<LocalizedResource> InitializeResources(string resources) => !string.IsNullOrWhiteSpace(resources)
            ? JsonSerializer.Deserialize<IEnumerable<LocalizedResource>>(resources)
            : Enumerable.Empty<LocalizedResource>();
    }
}
