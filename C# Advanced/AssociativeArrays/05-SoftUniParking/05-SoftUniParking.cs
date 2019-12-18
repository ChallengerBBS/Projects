using System;
using System.Collections.Generic;
using System.Linq;


namespace _05_SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var carsRegister = new Dictionary<string, string>();
            for (int i = 1; i <= count; i++)
            {
                string[] command = Console.ReadLine().Split();
                string name = command[1];
                
                if (command[0]=="register")
                {
                    string regNumber = command[2];
                    if (!carsRegister.ContainsKey(name))
                    {
                        carsRegister.Add(name, regNumber);
                        Console.WriteLine($"{name} registered {regNumber} successfully");
                    }
                    else
                        Console.WriteLine($"ERROR: already registered with plate number {regNumber}");
                }
                else if (command[0]=="unregister")
                {

                    if (carsRegister.ContainsKey(name))
                    {
                        carsRegister.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                    else
                        Console.WriteLine($"ERROR: user {name} not found");
                }

            }
            foreach (var item in carsRegister)
            {
                Console.WriteLine(item.Key+" => "+item.Value);
            }
        }
    }
}
