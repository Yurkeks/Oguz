using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Oguz.Areas
{
    public class FilesHelper
    {
        public static string UploadFile(string pathToSave, IFormFile file)
        {
            string filePath = string.Concat(pathToSave, file.FileName);
            string fileName = file.FileName;
            if (File.Exists(filePath))
            {
                fileName = Guid.NewGuid().ToString() + file.FileName;
                filePath = string.Concat(pathToSave, fileName);
            }
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return fileName;
        }
    }
}
