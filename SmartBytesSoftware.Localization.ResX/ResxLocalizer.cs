using System.Reflection;
using System.Resources;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SmartBytesSoftware.Localization.Abstractions;

namespace SmartBytesSoftware.Localization.Resx
{
    public class ResxLocalizer : ResourceManagerStringLocalizer, ILocalizer
    {
        public ResxLocalizer(ResourceManager resourceManager, Assembly resourceAssembly, string baseName, IResourceNamesCache resourceNamesCache, ILogger logger)
            : base(resourceManager, resourceAssembly, baseName, resourceNamesCache, logger)
        {
        }

        string ILocalizer.this[string name] => base[name].Value;
    }
}
