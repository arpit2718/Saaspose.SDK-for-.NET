using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf

{

    /// <summary>
    /// represents a single Pdf Link in document
    /// </summary>
    
    public class Link
    {
        public Link() { }

        public LinkActionType ActionType { get; set; }
        public string Action { get; set; }
        public LinkHighlightingMode Highlighting { get; set; }
        public Color Color { get; set; }
  
        
    }
}
