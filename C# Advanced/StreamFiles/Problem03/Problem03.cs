using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Problem03
{
    class Program
    {
        static void Main(string[] args)
        {
            var textPath = @"text.txt";
            var wordsPath = @"words.txt";
            string[] textLines = File.ReadAllLines(textPath);
            string[] words = File.ReadAllLines(wordsPath);

            var wordsInfo = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!wordsInfo.ContainsKey(word))
                {
                    wordsInfo.Add(word, 0);
                }
                
            }
            foreach (var currentLine in textLines)
            {
                string[] currentLineWords = currentLine.Split(new char[] { ' ', '-', ',', '.', '!', '?', '\\' });
                foreach (var currentWord in currentLineWords)
                {
                    if (wordsInfo.ContainsKey(currentWord))
                    {
                        wordsInfo[currentWord]++;
                    }
                }
            }
            string actualResultPath = "actualResult.txt";
            string expectedResultPath = "expectedResultPath.txt";
            foreach (var (key, value) in wordsInfo)
            {
                File.AppendAllText(actualResultPath, $"{key} - {value} { Environment.NewLine}");
            }
            foreach (var (key, value) in wordsInfo.OrderByDescending(x => x.Value))
            {
                File.AppendAllText(expectedResultPath, $"{key} - {value} { Environment.NewLine}"
                    );
            }
        }
    }
}
