﻿

namespace AutoRepairService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class AutoRepair

    {
        static void Main(string[] args)
        {
            string[] carModels = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var queueOfCars = new Queue<string>(carModels);
            var servedCars = new Stack<string>();
            string input = Console.ReadLine();
            while (input !="End")
            {
                if (input=="Service" && queueOfCars.Count>0)
                {
                    string currentCar = queueOfCars.Dequeue();
                    servedCars.Push(currentCar);
                    Console.WriteLine($"Vehicle {currentCar} got served.");
                }
                else if (input.Contains("CarInfo"))
                {
                    string carName = input.Split('-')[1];
                    if (queueOfCars.Contains(carName))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }
                else if (input=="History")
                {
                    Console.WriteLine(string.Join(", ",servedCars));
                }

                input = Console.ReadLine();
            }
            if (queueOfCars.Count>0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ",queueOfCars)}");
            }
            
                Console.WriteLine($"Served vehicles: {string.Join(", ", servedCars)}");
            
        }
    }
}