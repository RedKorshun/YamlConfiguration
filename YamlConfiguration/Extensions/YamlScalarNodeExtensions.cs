// Copyright Nate Barbettini.
// Licensed under the Apache License, Version 2.0.
// File was changed. See original here: https://github.com/nbarbettini/FlexibleConfiguration/blob/master/src/FlexibleConfiguration/Providers/YamlVisitors/ContextAwareVisitor.cs
using System;
using SharpYaml.Serialization;
using YamlConfiguration.Constants;

namespace YamlConfiguration.Extensions
{
    /// <summary>
    /// https://yaml.org/type/null.html
    /// </summary>
    internal static class YamlScalarNodeExtensions
    {
        public static Boolean IsNull(this YamlScalarNode scalar)
        {
            if (String.IsNullOrEmpty(scalar.Value))
            {
                return true;
            }

            if (String.Equals(scalar.Tag, YamlNullTypes.URI, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (String.Equals(scalar.Value, YamlNullTypes.Canonical, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (String.Equals(scalar.Value, YamlNullTypes.English, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }
    }
}