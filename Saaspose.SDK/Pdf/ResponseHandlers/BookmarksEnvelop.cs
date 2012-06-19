using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents container part of the Bookmarks resource response
    /// </summary>
    public class BookmarksEnvelop
    {
        public List<LinkResponse> Links { get; set; }
        public List<Bookmark> List { get; set; }
    }
}
