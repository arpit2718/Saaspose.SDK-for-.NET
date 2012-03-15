using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class OleObject
    {
        public OleObject()
        {

        }

        public void GetOleObject(ImageFormat imageFormat)
        {
        }

        string Name{ get; set;}
        string Placement{ get; set;}
        int UpperLeftRow { get; set;}
        int Top{ get; set;}
        int UpperLeftColumn { get; set;}
        int Left{ get; set;}
        int LowerRightRow { get; set;}
        int Bottom { get; set; }
        int LowerRightColumn{ get; set;}
        int Right { get; set; }
        int Width { get; set;}
        int Height{ get; set;}
        int X { get; set;}
        int Y{ get; set;}
        bool DisplayAsIcon { get; set;}
        string FileType{ get; set;}
        string ImageSourceFullName { get; set;}
        bool IsAutoSize{ get; set;}
        bool IsLink { get; set; }
        string ProgID { get; set;}
        string SourceFullName{ get; set;}

    }
}
