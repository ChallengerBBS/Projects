using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Problem05
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileArray = Directory.GetFiles(".", "*.*");
            var dirInfo = new Dictionary<string, Dictionary<string, double>>();
            DirectoryInfo directoryInfo = new DirectoryInfo(".");
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ @"/report.txt" ;
            FileInfo[] allFiles = directoryInfo.GetFiles();
            foreach (var file in allFiles)
            {
                double size = file.Length / 1024d;
                string fileName = file.Name;
                string extension = file.Extension;
                if (!dirInfo.ContainsKey(extension))
                {
                    dirInfo.Add(extension, new Dictionary<string, double>());
                }
                if (!dirInfo[extension].ContainsKey(fileName))
                {
                    dirInfo[extension].Add(fileName, size);
                }

            }
            var sortedDictionary = dirInfo
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x=>x.Key, y=>y.Value);

            foreach (var (extension, value) in sortedDictionary)
            {
                File.AppendAllText(desktopPath, extension + Environment.NewLine);

                foreach (var (fileName, size) in value.OrderBy(x=>x.Value))
                {
                    File.AppendAllText(desktopPath, $"--{fileName} - {Math.Round(size, 3)}kb{Environment.NewLine}");
                }
            }
        }
    }
}
