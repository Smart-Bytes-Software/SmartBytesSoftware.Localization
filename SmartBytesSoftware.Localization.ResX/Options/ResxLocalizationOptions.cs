using System;
using Microsoft.Extensions.Localization;
using SmartBytesSoftware.Localization.Abstraction.Options;

namespace SmartBytesSoftware.Localization.Resx.Options
{
    public class ResxLocalizationOptions : LocalizationOptions, ILocalizationOptions
    {
        private const string UseResourceTypeErrorMessage = "Please use `ResourceType` property to set the resource";
        private const string ResourcePathResolverErrorMessage = "Resx resources are resolved automatically based on the `ResourceType`, please do not use this";

        public string ResourceName
        { 
            get => throw new NotImplementedException(UseResourceTypeErrorMessage);
            set => throw new NotImplementedException(UseResourceTypeErrorMessage);
        }

        public Func<string> ResourcePathResolver
        {
            get => throw new NotImplementedException(ResourcePathResolverErrorMessage);
            set => throw new NotImplementedException(ResourcePathResolverErrorMessage);
        }

        public Type ResourceType { get; set; }
    }
}
