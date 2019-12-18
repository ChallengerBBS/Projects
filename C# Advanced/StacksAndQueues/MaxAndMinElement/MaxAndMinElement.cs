using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxAndMinElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfQueries = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            for (int i = 0; i < numOfQueries; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var cmd = input[0];
                
                switch (cmd)
                {
                    case 1:
                        {
                            var number = input[1];
                            stack.Push(number);
                            break;
                        }
                    case 2:
                        {
                            if (stack.Count > 0)
                                stack.Pop();
                            break;
                        }
                    case 3:
                        {
                            if (stack.Count > 0)
                            {
                                int maxNumberToPrint = int.MinValue;
                                foreach (var number in stack)
                                {
                                    if (maxNumberToPrint < number)
                                        maxNumberToPrint = number;
                                }
                                Console.WriteLine(maxNumberToPrint);
                                
                            }
                            
                            break;
                        }
                    case 4:
                        {
                            if (stack.Count > 0)
                            {
                                int minNumberToPrint = int.MaxValue;
                                foreach (var number in stack)
                                {
                                    if (minNumberToPrint > number)
                                        minNumberToPrint = number;
                                }
                                Console.WriteLine(minNumberToPrint);
                                
                            }
                           
                            break;
                        }
                }


            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
