using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSYmbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var symbolsCounter = new Dictionary<char, int>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (!symbolsCounter.ContainsKey(currentChar))
                {
                    symbolsCounter.Add(currentChar, 0);
                }
                symbolsCounter[currentChar]++;
            }

            foreach (var (key, value) in symbolsCounter.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{key}: {value} time/s");
            }

        }
    }
}
