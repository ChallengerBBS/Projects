using System;
using System.Collections.Generic;
using System.Linq;

namespace _04ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandLine = command.Split();
                ExecuteNumbers(numbers, commandLine);
                
            }
            Console.WriteLine(String.Join(' ', numbers));
        }

        private static void ExecuteNumbers(List<int> numbers, string[] commandLine)
        {
            if (commandLine[0] == "Add")
            {
                numbers.Add(int.Parse(commandLine[1]));
            }
            else if (commandLine[0] == "Remove")

            {
                int index = int.Parse(commandLine[1]);
                if (index >= 0 && index < numbers.Count)
                    numbers.RemoveAt(index);
                else
                    Console.WriteLine("Invalid index");

            }
            else if (commandLine[0] == "Insert")
            {
                int index = int.Parse(commandLine[2]);
                if (index >= 0 && index < numbers.Count)
                {
                    numbers.Insert(index, int.Parse(commandLine[1]));
                }
                else
                    Console.WriteLine("Invalid index");
            }
            else if (commandLine[0] == "Shift")
            {
                string direction = commandLine[1];
                int position = int.Parse(commandLine[2]);
                ShiftLists(numbers, direction, position);
            }
        }

        private static void ShiftLists(List<int> numbers, string direction, int position)
        {
            if (direction == "left")
            {
                for (int i = 0; i < position; i++)
                {
                    numbers.Add(numbers[0]);
                    numbers.RemoveAt(0);
                }
            }
            else if (direction == "right")
            {
                for (int i = 0; i < position; i++)
                {
                    numbers.Insert(0, numbers[numbers.Count-1]);
                    numbers.RemoveAt(numbers.Count-1);
                }
            }
        }
        
    }
}
