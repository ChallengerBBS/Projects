using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;

namespace Problem06
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "copyMe.png";
            string zipFile = "../../../result.zip";

            using (var archive = ZipFile.Open(zipFile, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(file, Path.GetFileName(file));
            }
            
        }
    }
}
