using System;
using System.Reflection;
using SmartBytesSoftware.Localization.Abstraction.Options;

namespace SmartBytesSoftware.Localization.Json.Options
{
    public class JsonLocalizationOptions : ILocalizationOptions
    {
        public string ResourcesPath { get; set; }

        public string ResourceName { get; set; }

        public Func<string> ResourcePathResolver { get; set; }
    }
}
