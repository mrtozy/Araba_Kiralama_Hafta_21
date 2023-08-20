using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using MimeDetective;
using System;
using System.IO;
namespace Core.Utilities.Helpers
{

    public class FileHelperManager 
    {
        public static void Write(IFormFile file, string directory, string fileName)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (Stream fileStream = new FileStream(directory + "\\" + fileName, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
        }

        public static void Write(IFormFile file, string fullPath)
        {
            string directory = Path.GetDirectoryName(fullPath);
            string fileName = Path.GetFileName(fullPath);
            Write(file, directory, fileName);
        }


        public static void Delete(string path)
        {
            File.Delete(path);
        }

        public static Stream GetFileStream(string path)
        {
            using (Stream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return fileStream;
            }
        }
    }
}
