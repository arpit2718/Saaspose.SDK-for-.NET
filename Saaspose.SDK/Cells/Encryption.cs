using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class Encryption
    {
        public Encryption()
        { 
        
        }

        public EncryptionType EncryptionType { get; set;}
        public string Password { get; set;}
        public int Keylength { get; set;}       

    }
}
