// Copyright Nate Barbettini.
// Licensed under the Apache License, Version 2.0.
// File was changed. See original here: https://github.com/nbarbettini/FlexibleConfiguration/blob/master/src/FlexibleConfiguration/Providers/YamlProvider.cs
using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using YamlConfiguration.Parsers;

namespace YamlConfiguration.Providers
{
    public class YamlConfigurationProvider : ConfigurationProvider
    {
        private readonly String _yaml;
        private readonly String _root;

        public YamlConfigurationProvider(in String yaml, in String root)
        {
            _yaml = yaml;
            _root = root;
        }

        public override void Load()
        {
            if (String.IsNullOrEmpty(_yaml))
            {
                return;
            }

            YamlParser parser = new YamlParser(_root);

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(_yaml)))
            {
                Data = parser.Parse(stream);
            }
        }
    }
}
