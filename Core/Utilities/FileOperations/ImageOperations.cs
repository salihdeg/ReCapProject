using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileOperations
{
    public class ImageOperations
    {
        public static bool CopyFileToServer(IFormFile imageFile,string destinationFolder, string newName)
        {
            try
            {
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }
                using (FileStream fileStream = System.IO.File.Create(destinationFolder + newName))
                {
                    imageFile.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool DeleteFileFromServer(string filePath)
        {
            try
            {
                File.Delete(filePath);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
