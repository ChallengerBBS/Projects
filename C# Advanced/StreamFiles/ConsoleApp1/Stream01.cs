using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "files";
            var inputFile = "input.txt";
            var outputFile = "output.txt";
            var inputPath = Path.Combine(path, inputFile );
            var outputPath = Path.Combine(path, outputFile);

            using (var reader = new StreamReader(inputPath))
            {
                int count = 0;

                string line = reader.ReadLine();
                using (var writer = new StreamWriter(outputPath))
                {
                    while (line != null)
                    {
                        if (count % 2 != 0)
                        {
                            Console.WriteLine(line);
                        }
                        count++;
                        line = reader.ReadLine();
                    }
                }

                while(line != null)
                {
                    if (count%2!=0)
                    {
                        Console.WriteLine(line);
                    }
                    count++;
                    line = reader.ReadLine();
                }
              

            }
        }
    }
}
