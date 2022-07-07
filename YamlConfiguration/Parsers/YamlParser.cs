// Copyright Nate Barbettini.
// Licensed under the Apache License, Version 2.0.
// File was changed. See original here: https://github.com/nbarbettini/FlexibleConfiguration/blob/master/src/FlexibleConfiguration/Providers/YamlParser.cs
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using SharpYaml.Serialization;
using YamlConfiguration.Parsers.Visitors;

namespace YamlConfiguration.Parsers
{
    internal sealed class YamlParser
    {
        private readonly String _root;

        public YamlParser(String root = null)
        {
            _root = root;
        }

        public IDictionary<String, String> Parse(Stream input)
        {
            IDictionary<String, String> data = new SortedDictionary<String, String>(StringComparer.OrdinalIgnoreCase);
            ContextAwareYamlVisitor visitor = new ContextAwareYamlVisitor();

            YamlStream yamlStream = new YamlStream();

            using (StreamReader reader = new StreamReader(input))
            {
                yamlStream.Load(reader);

            }

            if (yamlStream.Documents.Count == 0)
            {
                return data;
            }

            yamlStream.Accept(visitor);

            foreach (KeyValuePair<String, String> item in visitor.Items)
            {
                String key = item.Key;

                if (!String.IsNullOrEmpty(_root))
                {
                    key = ConfigurationPath.Combine(_root, key);
                }

                if (data.ContainsKey(key))
                {
                    throw new FormatException(String.Format("The key '{0}' is duplicated.", key));
                }

                data[key] = item.Value;
            }

            return data;
        }
    }
}