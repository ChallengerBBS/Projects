using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB_03_WordSynonims
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, List<string>>();
            for (int i = 1; i <= n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (!dictionary.ContainsKey(word))
                {
                    dictionary[word] = new List<string>();
                }
                dictionary[word].Add(synonym);
            }
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} - {String.Join(", ",item.Value)}");
            }
        }
    }
}
