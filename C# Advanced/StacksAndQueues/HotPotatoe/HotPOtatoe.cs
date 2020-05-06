using System;
using System.Collections.Generic;
using System.Linq;

namespace HotPotatoe
{
    class Program
    {
        static void Main(string[] args)
        {
            var competitors = Console.ReadLine().Split();
            var queue = new Queue<string>(competitors);
            var tosses = int.Parse(Console.ReadLine());
            while (queue.Count>1)
            {
                for (int i = 0; i < tosses-1; i++)
                {
                    string player = queue.Dequeue();
                    queue.Enqueue(player);
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
