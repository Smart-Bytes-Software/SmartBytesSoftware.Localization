using SmartBytesSoftware.Localization.Abstractions;
using SmartBytesSoftware.Localization.Models;

namespace SmartBytesSoftware.Localization.Json
{
    public class JsonLocalizer : ILocalizer
    {
        private readonly LocalizedResourceDictionary resources;

        public JsonLocalizer(LocalizedResourceDictionary resources)
        {
            this.resources = resources;
        }

        public string this[string name] => resources[name];
    }
}
