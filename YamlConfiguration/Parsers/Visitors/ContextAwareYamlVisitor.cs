// Copyright Nate Barbettini.
// Licensed under the Apache License, Version 2.0.
// File was changed. See original here: https://github.com/nbarbettini/FlexibleConfiguration/blob/master/src/FlexibleConfiguration/Providers/YamlVisitors/ContextAwareVisitor.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using SharpYaml.Serialization;
using YamlConfiguration.Extensions;

namespace YamlConfiguration.Parsers.Visitors
{
    internal class ContextAwareYamlVisitor : YamlVisitorBase
    {
        protected readonly Stack<String> context;
        protected readonly List<KeyValuePair<String, String>> items = new List<KeyValuePair<String, String>>();

        public ContextAwareYamlVisitor(Stack<String> context = null)
        {
            this.context = context == null
                ? new Stack<String>()
                : new Stack<String>(context.Reverse());
        }

        public IReadOnlyList<KeyValuePair<String, String>> Items => this.items;

        protected override void VisitPair(YamlNode key, YamlNode value)
        {
            EnterContext(key as YamlScalarNode);
            value.Accept(this);
            ExitContext();
        }

        protected override void Visit(YamlScalarNode scalar)
        {
            String key = ConfigurationPath.Combine(context.Reverse());

            String value = scalar.IsNull()
                ? String.Empty
                : scalar.Value;

            this.items.Add(new KeyValuePair<String, String>(key, value));
        }

        protected override void Visit(YamlMappingNode mapping)
        {
            ContextAwareMappingYamlVisitor nestedVisitor = new ContextAwareMappingYamlVisitor(context);
            mapping.Accept(nestedVisitor);

            foreach (KeyValuePair<String, String> item in nestedVisitor.Items)
            {
                this.items.Add(new KeyValuePair<String, String>(item.Key, item.Value));
            }
        }

        protected override void Visit(YamlSequenceNode sequence)
        {
            ContextAwareSequenceYamlVisitor nestedVisitor = new ContextAwareSequenceYamlVisitor(context);
            sequence.Accept(nestedVisitor);

            foreach (KeyValuePair<String, String> item in nestedVisitor.Items)
            {
                this.items.Add(new KeyValuePair<String, String>(item.Key, item.Value));
            }
        }

        protected void EnterContext(YamlScalarNode scalar)
        {
            String value = scalar.IsNull()
                ? String.Empty
                : scalar.Value;

            EnterContext(value);
        }

        protected void EnterContext(in String rawContext)
        {
            String context = rawContext ?? String.Empty;
            this.context.Push(context);
        }

        protected void ExitContext()
        {
            this.context.Pop();
        }
    }
}