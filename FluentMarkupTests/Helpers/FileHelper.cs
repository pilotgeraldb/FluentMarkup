using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace FluentMarkupTests.Helpers
{
    public class FileHelper
    {
        public static string GetFile(string path)
        {
            byte[] binData = null;

            if(!File.Exists(path))
            {
                path = "Data/" + path;
            }

            if(!File.Exists(path))
            {
                Console.WriteLine($"file at {path} does not exist");
                return string.Empty;
            }

           using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
           {
               byte[] buffer = new byte[16 * 1024];
               using (MemoryStream ms = new MemoryStream())
               {
                   int read;
                   while ((read = fs.Read(buffer, 0, buffer.Length)) > 0)
                   {
                       ms.Write(buffer, 0, read);
                   }
                   binData = ms.ToArray();
               }
           }

           return Encoding.ASCII.GetString(binData);
        }
    }
}