// Copyright Nate Barbettini.
// Licensed under the Apache License, Version 2.0.
// File was changed. See original here: https://github.com/nbarbettini/FlexibleConfiguration/blob/master/src/FlexibleConfiguration/ConfigurationBuilderProviderExtensions.cs
using System;
using YamlConfiguration.Files;
using YamlConfiguration.Sources;

namespace Microsoft.Extensions.Configuration
{
    public static class YamlConfigurationBuilderExtensions
    {
        /// <summary>
        /// Adds configuration values from a YAML string.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <param name="yaml">The YAML string.</param>
        /// <param name="root">
        /// An optional root name to apply to any configuration values.
        /// For example, if <paramref name="root"/> is <c>foo</c>, and the value <c>bar = baz</c>
        /// is discovered, the actual added value will be <c>foo.bar = baz</c>.
        /// </param>
        public static IConfigurationBuilder AddYaml(
            this IConfigurationBuilder builder,
            String yaml,
            String root = null)
        {
            YamlConfigurationSource source = new YamlConfigurationSource(yaml, root);
            return builder.Add(source);
        }

        /// <summary>
        /// Adds configuration values from a YAML file.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <param name="filePath">The file path.</param>
        /// <param name="optional">
        /// Determines whether the file can be skipped silently. If <paramref name="optional"/> is <see langword="false"/>,
        /// and the file does not exist, a <see cref="System.IO.FileNotFoundException"/> will be thrown. If <paramref name="optional"/>
        /// is <see langword="true"/>, the method will return silently.
        /// </param>
        /// <param name="root">
        /// An optional root name to apply to any configuration values.
        /// For example, if <paramref name="root"/> is <c>foo</c>, and the value <c>bar = baz</c>
        /// is discovered, the actual added value will be <c>foo.bar = baz</c>.
        /// </param>
        public static IConfigurationBuilder AddYamlFile(
            this IConfigurationBuilder builder,
            String filePath,
            Boolean optional = false,
            String root = null)
        {
            String yaml = FileOperations.Load(filePath, optional);
            return builder.AddYaml(yaml, root);
        }
    }
}