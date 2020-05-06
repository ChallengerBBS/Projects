using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_CountCharsAsString
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().Where(x=>x!=' ').ToArray();
            var dict = new Dictionary<char, int>();
            foreach (var character in input)
            {
                if (!dict.ContainsKey(character))
                {
                    dict[character] = 0;
                }
                dict[character]++;

            }
            foreach (var line in dict)
            {
                Console.WriteLine(line.Key+" -> "+line.Value);
            }
        }
    }
}
