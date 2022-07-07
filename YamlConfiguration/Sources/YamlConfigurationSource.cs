// Licensed under the Apache License, Version 2.0.
using System;
using Microsoft.Extensions.Configuration;
using YamlConfiguration.Providers;

namespace YamlConfiguration.Sources
{
    public class YamlConfigurationSource : IConfigurationSource
    {
        private readonly String _yaml;
        private readonly String _root;

        public YamlConfigurationSource(in String yaml, in String root)
        {
            _yaml = yaml;
            _root = root;
        }

        IConfigurationProvider IConfigurationSource.Build(IConfigurationBuilder builder)
        {
            return new YamlConfigurationProvider(_yaml, _root);
        }
    }
}