using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficJam
{



    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var cars = new Queue<string>();
            int number = 0;
            var command = Console.ReadLine();
            while (command.ToLower() != "end")
            {
                if (command.ToLower() == "green")
                {
                    int currentCount = cars.Count > count ? count : cars.Count;
                    for (int i = 0; i < currentCount; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        number++;
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{number} cars passed the crossroads.");
        }
    }


}
