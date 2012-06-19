using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Words
{
    public class DrawingObjects
    {

        public DrawingObjects() { }

        public List<Saaspose.Words.List> List { get; set; }
        public LinkResponse link { get; set; }
    }

    public class List
    {
        public LinkResponse link { get; set; }
    }
}
