using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB_01_CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var numbersAsString = input.Split().Select(double.Parse).ToList();
            var counts = new SortedDictionary<double, int>();
            foreach (var eachNumber in numbersAsString)
            {
                if(counts.ContainsKey(eachNumber))
                {
                    counts[eachNumber] += 1;
                }
                else
                {
                    counts[eachNumber] = 1;
                }
            }
            foreach (var item in counts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}
