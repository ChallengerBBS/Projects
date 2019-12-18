using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();
            Func<int, int> incrementByOne = x => x += 1;
            Func<int, int> subtractByOne = x => x -= 1;
            Func<int, int> multiply = x => x *= 2;

            Action<int[]> printResult = number => 
            Console.WriteLine(string.Join(" ", number));

            var command = Console.ReadLine();
            while (command!="end")
            {
                if(command=="add")
                {
                    inputNumbers = inputNumbers.Select(incrementByOne).ToArray();
                }
                else if (command == "multiply")
                {
                    inputNumbers = inputNumbers.Select(multiply).ToArray();
                }
                else if (command == "subtract")
                {
                    inputNumbers = inputNumbers.Select(subtractByOne).ToArray();
                }
                else if (command=="print")
                {
                    printResult(inputNumbers);
                }
                command = Console.ReadLine();
            }
        }
    }
}
