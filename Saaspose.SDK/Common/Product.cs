using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Common
{
    /// <summary>
    /// this class represents product information
    /// </summary>
    public class Product
    {
        /// <summary>
        /// this property represents the base product uri i.e. http://api.saaspose.com/v1.0
        /// you can set this property according to the current version you're using
        /// </summary>
        public static string BaseProductUri { get; set; }
    }
}
