using System;
using System.Collections.Generic;
using System.Linq;

namespace Zad01
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var collector = new Stack<char>();
            foreach (var character in input)
            {
                collector.Push(character);
            }
            while (collector.Count > 0)
            {
                Console.Write(collector.Pop());
            }
            Console.WriteLine();
        }
    }
}
