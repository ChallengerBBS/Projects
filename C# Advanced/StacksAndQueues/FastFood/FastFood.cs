﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            var food = int.Parse(Console.ReadLine());

            int[] sells = Console.ReadLine()
                .Split(" ").Select(int.Parse).ToArray();

            

            var queue = new Queue<int>(sells);

            int bigestSell = queue.Max();

            for (int i = 0; i < sells.Length; i++)
            {
                int consumingFood = sells[i];
                if (consumingFood <= food)
                {
                    food -= consumingFood;
                    queue.Dequeue();
                }
            }
            if (queue.Count > 0)
            {
                Console.WriteLine(bigestSell);
                Console.Write("Orders left: ");
                foreach (var orders in queue)
                {
                    Console.Write($"{orders} ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(bigestSell + Environment.NewLine + "Orders complete");
            }
        }
    }
}