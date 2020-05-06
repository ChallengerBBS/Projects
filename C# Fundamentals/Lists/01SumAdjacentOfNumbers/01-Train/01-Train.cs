using System;
using System.Collections.Generic;
using System.Linq;


namespace _01_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfPassengersPerWagon = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxCapacityPerWagon = int.Parse(Console.ReadLine());
            List<string> command = Console.ReadLine().Split().ToList();

            while (command[0] != "end")
            {
                
                if(command[0]=="Add")
                {
                    countOfPassengersPerWagon.Add(int.Parse(command[1]));
                }
                else
                {
                    for (int i = 0; i < countOfPassengersPerWagon.Count; i++)
                    {
                        if (countOfPassengersPerWagon[i] + (int.Parse(command[0])) <= maxCapacityPerWagon)
                        {
                            countOfPassengersPerWagon[i] += int.Parse(command[0]);
                            break;
                            
                        }
                        

                    }
                }

                command= Console.ReadLine().Split().ToList();
            }
            Console.WriteLine(String.Join(' ', countOfPassengersPerWagon));
        }
    }
}
