using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents a single bookmark in document
    /// </summary>

   public class Bookmark
    {
        public Bookmark() { }

      //  public List<LinkResponse> Links { get; set; }
        public string Title { get; set; }
        public bool Italic { get; set; }
        public bool Bold { get; set; }
        public Color Color { get; set; }
          
    }
}
