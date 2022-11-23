using Microsoft.Extensions.DependencyInjection;
using SmartBytesSoftware.Localization.Abstractions;
using System.Globalization;
using Microsoft.Extensions.Logging;
using SmartBytesSoftware.Localization.Json.Configuration;

IServiceCollection services = new ServiceCollection();

services.AddJsonLocalizationProvider(options =>
{
    options.ResourcesPath = "Resources";
    options.ResourceName = "Resource";
});

services.AddSingleton<ILoggerFactory, LoggerFactory>();

IServiceProvider serviceProvider = services.BuildServiceProvider();

CultureInfo.CurrentCulture = new CultureInfo("en-US");
CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture;

ILocalizer? localizer = serviceProvider.GetService<ILocalizer>();

Console.WriteLine($"Localizer in English: {localizer!["PersonName"]}");

CultureInfo.CurrentCulture = new CultureInfo("bg-BG");
CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture;

localizer = serviceProvider.GetService<ILocalizer>();

Console.WriteLine($"Localizer in Bulgarian: {localizer!["PersonName"]}");

Console.ReadLine();