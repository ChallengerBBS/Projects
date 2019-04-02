using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            int startIndexOfFile = path.LastIndexOf('\\') + 1;
            string file = path.Substring(startIndexOfFile);
            var specs = file.Split(".");
            string fileName = specs[0];
            string fileType = specs[1];
            Console.WriteLine("File name: "+fileName);
            Console.WriteLine("File extension: "+fileType);
        }
    }
}
