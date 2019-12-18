using System;
using System.IO;
using System.Linq;

namespace Problem02
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "text.txt";
            string outputPath = "output.txt";
            var test = File.ReadAllLines(inputPath);
            int lineCounter = 1;
            foreach (var currentLine in test)
            {
                
                int lettersCount = currentLine.Count(char.IsLetter);
                int punctuationCount = currentLine.Count(char.IsPunctuation);
                File.AppendAllText(outputPath, $"Line {lineCounter}: {currentLine} ({lettersCount})({punctuationCount}){Environment.NewLine}");
                lineCounter++;
            }
        }
    }
}
