using System.Globalization;
using ConsoleApp.Resx.Resources;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartBytesSoftware.Localization.Abstractions;
using SmartBytesSoftware.Localization.Abstractions.Providers;
using SmartBytesSoftware.Localization.Resx.Configuration;

IServiceCollection services = new ServiceCollection();

services.AddResxLocalizationProvider(options =>
{
    options.ResourceType = typeof(Resource);
});

services.AddSingleton<ILoggerFactory, LoggerFactory>();

IServiceProvider serviceProvider = services.BuildServiceProvider();

ILocalizer? localizer = serviceProvider.GetService<ILocalizer>();

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CurrentCulture;

Console.WriteLine($"Localizer in English: {localizer![nameof(Resource.Name)]}");

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("bg-BG");
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CurrentCulture;

Console.WriteLine($"Localizer in Bulgarian: {localizer![nameof(Resource.Name)]}");
Console.ReadLine();