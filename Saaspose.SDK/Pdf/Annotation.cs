using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents a single annotation in document
    /// </summary>

    public class Annotation
    {
        public Annotation() { }

      //  public List<LinkResponse> Links { get; set; }
        public Color Color { get; set; }
        public string Contents { get; set; }
        public string CreationDate { get; set; }
        public string Subject { get; set; }
        public string Title { get; set; }
        public string Modified { get; set; }
      

    }
}
