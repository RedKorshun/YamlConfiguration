// Copyright Nate Barbettini.
// Licensed under the Apache License, Version 2.0.
// File was changed. See original here: https://github.com/nbarbettini/FlexibleConfiguration/blob/master/src/FlexibleConfiguration/Providers/YamlVisitors/ContextAwareSequenceVisitor.cs
using System;
using System.Collections.Generic;
using SharpYaml.Serialization;

namespace YamlConfiguration.Parsers.Visitors
{
    internal sealed class ContextAwareSequenceYamlVisitor : ContextAwareYamlVisitor
    {
        private Int32 _index = 0;

        public ContextAwareSequenceYamlVisitor(Stack<String> context = null)
            : base(context)
        {
        }

        protected override void Visit(YamlSequenceNode sequence)
        {
            VisitChildren(sequence);
        }

        protected override void VisitChildren(YamlSequenceNode sequence)
        {
            foreach (YamlNode node in sequence.Children)
            {
                this.EnterContext(_index.ToString());

                ContextAwareYamlVisitor visitor = new ContextAwareYamlVisitor(context);
                node.Accept(visitor);
                this.items.AddRange(visitor.Items);

                this.ExitContext();
                _index++;
            }
        }
    }
}