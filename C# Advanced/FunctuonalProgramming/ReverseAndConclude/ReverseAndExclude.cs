using System;
using System.Linq;
using System.Collections.Generic;

namespace ReverseAndConclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int divisor = int.Parse(Console.ReadLine());
            Func<int, bool> filter = number => number % divisor != 0;
            numbers = numbers.Reverse().Where(filter).ToArray();
            
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}