using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Slides;

namespace Saaspose.SDK.Slides
{
    public class BackgroundStyles
    {
        public string Href { get; set; }
        public string Relation { get; set; }
        public string LinkType { get; set; }
        public string Title { get; set; }
    }
    public class EffectStyles
    {
        public string Href { get; set; }
        public string Relation { get; set; }
        public string LinkType { get; set; }
        public string Title { get; set; }
    }
    public class FillStyles
    {
        public string Href { get; set; }
        public string Relation { get; set; }
        public string LinkType { get; set; }
        public string Title { get; set; }
    }
    public class LineStyles
    {
        public string Href { get; set; }
        public string Relation { get; set; }
        public string LinkType { get; set; }
        public string Title { get; set; }
    }
    public class FormatScheme
    {
        public FormatScheme() { }
        public UriResponse SelfUri { get; set; }
        public BackgroundStyles[] BackgroundStyles { get; set; }
        public EffectStyles[] EffectStyles { get; set; }
        public FillStyles[] FillStyles { get; set; }
        public LineStyles[] LineStyles { get; set; }
    }
}
