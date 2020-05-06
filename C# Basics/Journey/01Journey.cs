using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            if (budget <= 100)
            {
                if (season == "summer")
                {
                    budget = budget * 0.3;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Camp - {budget:f2}");
                }
                else if (season == "winter")
                {
                    budget = budget * 0.7;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Hotel - {budget:f2}");
                }
            }
            else if (budget <= 1000)
            {
                if (season == "summer")
                {
                    budget = budget * 0.4;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Camp - {budget:f2}");
                }
                else if (season == "winter")
                {
                    budget = budget * 0.8;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Hotel - {budget:f2}");
                }
            }
            else if (budget > 1000)
            {
                budget = budget * 0.9;
                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine($"Hotel - {budget:f2}");
            }
        }
    }
}
