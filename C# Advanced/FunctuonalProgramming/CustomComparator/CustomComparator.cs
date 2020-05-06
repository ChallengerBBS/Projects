using System;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Func<int, int, int> sortFunc = (x, y)
                 => (x % 2 == 0 && y % 2 != 0) ? -1
                 : (x % 2 != 0 && y % 2 == 0) ? 1
                 : x > y ? 1 : x < y ? -1 : 0;
            Array.Sort(input, (x, y) => sortFunc(x, y));
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
