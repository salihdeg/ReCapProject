using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Constants
{
    public static class ImageInfo
    {
        public static string DefaultImageFolder = Directory.GetParent(Directory.GetCurrentDirectory()) + @"\Images\";
        public static string DefaultImage = DefaultImageFolder+ "defaultLogo.jpg";
    }
}
