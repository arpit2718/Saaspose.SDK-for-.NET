using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Slides
{
    /// <summary>
    /// represents container part of the slides resource response
    /// </summary>
    public class SlidesEnvelop
    {

        public List<string> AlternateLinks { get; set; }
        public List<string> Links { get; set; }
        public string SelfUri { get; set; }
        public List<SlideResponse> SlideList { get; set; }
    }
}
