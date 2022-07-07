// Copyright Nate Barbettini.
// Licensed under the Apache License, Version 2.0.
// File was changed. See original here: https://github.com/nbarbettini/FlexibleConfiguration/blob/master/src/FlexibleConfiguration/Providers/YamlVisitors/ContextAwareMappingVisitor.cs
using System;
using System.Collections.Generic;
using SharpYaml.Serialization;

namespace YamlConfiguration.Parsers.Visitors
{
    internal sealed class ContextAwareMappingYamlVisitor : ContextAwareYamlVisitor
    {
        public ContextAwareMappingYamlVisitor(Stack<String> context = null)
            : base(context)
        {
        }

        protected override void Visit(YamlMappingNode mapping)
        {
            VisitChildren(mapping);
        }
    }
}