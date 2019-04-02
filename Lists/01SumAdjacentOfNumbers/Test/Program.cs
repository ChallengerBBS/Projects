using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();
           
            for (int i = 0; i < numbers.Count; i++)
            {
                characters.Add( numbers[i]);
            }


            Console.WriteLine(characters);
        }
    }
}