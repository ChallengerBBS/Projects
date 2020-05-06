using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rack = new Stack<int>(clothes);
            int rackCapacity = int.Parse(Console.ReadLine());
            int clothesSum = 0;
            int usedRacksCount = 1;


            foreach (var item in rack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(usedRacksCount);
        }
    }
}
