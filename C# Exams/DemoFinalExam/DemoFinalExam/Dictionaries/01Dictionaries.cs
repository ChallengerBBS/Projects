using System;
using System.Linq;
using System.Collections.Generic;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" | ").ToList();
            var dictionary = new Dictionary<string, List<string>>();
            for (int i = 0; i < input.Count; i++)
            {
                var wordAndDefinition = input[i].Split(": ");
                var word = wordAndDefinition[0];
                var definition = wordAndDefinition[1];

                if (dictionary.ContainsKey(word))
                {
                    dictionary[word].Add(definition);
                }
                else
                {
                    dictionary[word] = new List<string> { definition };
                }

                
            }

            var wordsToPrint = Console.ReadLine().Split(" | ").ToList();

            

            foreach (var word in wordsToPrint)
            {
                if (dictionary.ContainsKey(word))
                {
                    Console.WriteLine(word);
                    foreach (var definition in dictionary[word].OrderByDescending(x=>x.Length))
                    {
                        Console.WriteLine("-"+definition);
                    }
                }
            }
            var command = Console.ReadLine();
            if (command=="List")
            {
                Console.WriteLine(string.Join(" ", dictionary.Keys.OrderBy(x=>x)));
            }
            else if (command=="End")
            {
                return;
            }



            

         

        }
    }
}
