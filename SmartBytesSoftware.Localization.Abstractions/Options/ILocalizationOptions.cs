using System;

namespace SmartBytesSoftware.Localization.Abstraction.Options
{
    public interface ILocalizationOptions
    {
        /// <summary>
        /// Gets or sets the path to the resource files location.
        /// </summary>
        string ResourcesPath { get; set; }

        /// <summary>
        /// Gets or sets the resource name to read from.
        /// </summary>
        string ResourceName { get; set; }

        Func<string> ResourcePathResolver { get; set; }
    }
}
