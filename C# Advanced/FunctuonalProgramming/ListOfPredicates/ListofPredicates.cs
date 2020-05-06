using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            var inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Distinct()
                .ToArray();
            var numbers = Enumerable.Range(1, range).ToList();

            var predicates = new List<Predicate<int>>();

            foreach (var currentNumber in inputNumbers)
            {
                predicates.Add(x => x % currentNumber == 0);
            }


            
            for (int i = 0; i < numbers.Count; i++)
            {
                foreach (var currentPredicate in predicates)
                {
                    if (!currentPredicate(numbers[i]))
                    {
                        numbers.Remove(numbers[i]);
                        i--;
                        break;

                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
