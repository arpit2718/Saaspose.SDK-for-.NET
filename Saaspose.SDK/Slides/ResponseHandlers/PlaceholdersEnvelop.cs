using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Slides;

namespace Saaspose.SDK.Slides.ResponseHandlers
{
    public class PlaceholdersEnvelop
    {
        public UriResponse SelfUri { get; set; }
        public List<PlaceholderURI> PlaceholderLinks { get; set; }
    }
}
