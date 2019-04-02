using System;
using System.Collections.Generic;
using System.Linq;

namespace _03HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            var guests = new List<string>();
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                if (tokens.Length==3)
                {
                    if (guests.Contains(tokens[0]))
                    {

                        Console.WriteLine($"{tokens[0]} is already in the list!");

                    }
                    else
                        guests.Add(tokens[0]);
                }
                else if (tokens.Length==4)
                {
                    if (guests.Contains(tokens[0]))
                    {
                        guests.Remove(tokens[0]);
                    }
                    else
                        Console.WriteLine($"{tokens[0]} is not in the list!");

                }

            }
            foreach (var eachGuest in guests)
            {
                Console.WriteLine(eachGuest);
            }
        }
    }
}
