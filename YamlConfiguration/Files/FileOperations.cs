// Copyright Nate Barbettini.
// Licensed under the Apache License, Version 2.0.
// File was changed. See original here: https://github.com/nbarbettini/FlexibleConfiguration/blob/master/src/FlexibleConfiguration/Providers/FileOperations.cs
using System;
using System.IO;

namespace YamlConfiguration.Files
{
    internal static class FileOperations
    {
        public static String Load(in String path, in Boolean optional)
        {
            return optional && !File.Exists(path)
                ? null
                : File.ReadAllText(path);
        }
    }
}