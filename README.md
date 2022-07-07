[![NuGet][nets-nuget-badge]][nets-nuget] 
[![NuGet][yaml-nuget-badge]][yaml-nuget] 
[![NuGet][mec-nuget-badge]][mec-nuget] 
[![NuGet][meca-nuget-badge]][meca-nuget] 

[nets-nuget]: https://www.nuget.org/packages/NETStandard.Library
[nets-nuget-badge]: https://img.shields.io/nuget/v/NETStandard.Library.svg?label=NETStandard.Library

[yaml-nuget]: https://www.nuget.org/packages/SharpYaml
[yaml-nuget-badge]: https://img.shields.io/nuget/v/SharpYaml.svg?label=SharpYaml

[mec-nuget]: https://www.nuget.org/packages/Microsoft.Extensions.Configuration
[mec-nuget-badge]: https://img.shields.io/nuget/v/Microsoft.Extensions.Configuration.svg?label=Microsoft.Extensions.Configuration

[meca-nuget]: https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Abstractions
[meca-nuget-badge]: https://img.shields.io/nuget/v/Microsoft.Extensions.Configuration.Abstractions.svg?label=Microsoft.Extensions.Configuration.Abstractions

# YamlConfiguration

[![NuGet](https://img.shields.io/nuget/v/YamlConfiguration.svg)](https://www.nuget.org/packages/YamlConfiguration)
YamlConfiguration is a small library to support the YAML format for .NET configuration files, nothing else.
> **Note** Package code it's an adaptation of YAML functionality from a popular (but obsolete) [FlexibleConfiguration](https://github.com/nbarbettini/FlexibleConfiguration) NuGet package.
> Unlike [FlexibleConfiguration](https://github.com/nbarbettini/FlexibleConfiguration) it uses .NET native configuration infrastructure and [SharpYaml](https://www.nuget.org/packages/SharpYaml) instead of [YamlDotNet](https://www.nuget.org/packages/YamlDotNet) to support YAML.

## Supported Platforms

* .NET 5 and higher
* .NET Core 2.0 and higher
* .NET Framework 4.6.1 and higher

## Getting the Code

* Nuget: `install-package YamlConfiguration` or `dotnet add package YamlConfiguration`
* Source code: `git clone git@github.com:RedKorshun/YamlConfiguration.git`

## How to use

Example for console application:
```csharp
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace YamlConfigurationHowTo
{
    internal sealed class Startup
    {
        internal static async Task Main(String[] args)
        {
            IHostBuilder hostBuilder = new HostBuilder()
                .ConfigureAppConfiguration(ConfigureConfiguration)
                .ConfigureServices(ConfigureServices);

            await hostBuilder.RunConsoleAsync();
        }

        private static void ConfigureConfiguration(IConfigurationBuilder config)
        {
            config
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddYamlFile("appsettings.yaml", optional: false) // <-- Exactly what this package provides
            ;
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddHostedService<ApplicationManager>() // <-- Your IHostedService implementation
                // Your dependency injection bindings
            ;
        }
    }
}
```

## License

Expat for YamlConfiguration and Apache 2.0 for the source code from [FlexibleConfiguration](https://github.com/nbarbettini/FlexibleConfiguration).

## Alternatives

* [NetEscapades.Configuration.Yaml](https://www.nuget.org/packages/NetEscapades.Configuration.Yaml) - uses [YamlDotNet](https://www.nuget.org/packages/YamlDotNet) which is an old and popular but currently its further developing is on hold.
* [other](https://www.nuget.org/packages?q=yaml+configuration).
