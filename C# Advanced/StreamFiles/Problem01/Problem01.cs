using System;
using System.IO;
using System.Linq;

namespace Problem01
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"../../../text.txt";
            int counter = 0;
            using (var reader = new StreamReader(filePath))
            {
                var currentLine = reader.ReadLine();
                while (currentLine!=null)
                {

                    if (counter % 2 == 0)
                    {
                        string replacedSymbols = ReplaceSpecialSymbols(currentLine);
                        string reversedWords = ReverseWords(replacedSymbols);
                        Console.WriteLine(reversedWords);
                        
                    }   
                    counter++;
                    currentLine = reader.ReadLine();
                }
            }
        }

        private static string ReverseWords(string replacedSymbols)
        {
            return string.Join(" ", replacedSymbols.Split().Reverse());
                
        }

        private static string ReplaceSpecialSymbols(string currentLine)
        {
            return currentLine.Replace(',', '@')
                .Replace('.', '@')
                .Replace('-', '@')
                .Replace('!', '@')
                .Replace('?', '@');
           
        }
    }
}
