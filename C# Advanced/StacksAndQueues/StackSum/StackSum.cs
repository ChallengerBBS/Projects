using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            var line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int number = 0;
            while (line[0]?.ToLower() != "end")
            {
                if (int.TryParse(line[0], out number))
                {
                    foreach (var item in line)
                    {
                        stack.Push(int.Parse(item));
                    }
                }
                else
                {
                    string command = line[0].ToLower();

                    switch (command)
                    {
                        case "add":
                            for (int i = 1; i < line.Length; i++)
                            {
                                stack.Push(int.Parse(line[i]));
                            }
                            break;
                        case "remove":
                            {
                                int count = int.Parse(line[1]);
                                if (count <= stack.Count)
                                {
                                    for (int i = 0; i < count; i++)
                                    {
                                        stack.Pop();
                                    }
                                }
                                else
                                {
                                    break;
                                }
                                break;
                            }
                    }
                }
                line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();



            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
