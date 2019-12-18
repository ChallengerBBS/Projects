using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            double left=0;
            if (category=="Normal")
            {
                if (1 <= count && count <= 4)
                    left = budget - (budget * 0.75);
                else if (5 <= count && count <= 9)
                    left = budget - (budget * 0.60);
                else if (10 <= count && count <= 24)
                    left = budget - (budget * 0.50);
                else if (25 <= count && count <= 49)
                    left = budget - (budget * 0.40);
                else if (50 <= count)
                    left = budget - (budget * 0.25);
                double ticketCost = count * 249.99;
                if (left > ticketCost)
                    Console.WriteLine($"Yes! You have {(left-ticketCost):f2} leva left." );
                else if (ticketCost>left)
                    Console.WriteLine($"Not enough money! You need {(ticketCost-left):f2} leva.");

            }
            if (category == "VIP")
            {
                if (1 <= count && count <= 4)
                    left = budget - (budget * 0.75);
                else if (5 <= count && count <= 9)
                    left = budget - (budget * 0.60);
                else if (10 <= count && count <= 24)
                    left = budget - (budget * 0.50);
                else if (25 <= count && count <= 49)
                    left = budget - (budget * 0.40);
                else if (50 <= count)
                    left = budget - (budget * 0.25);
                double ticketCost = count * 499.99;
                if (left > ticketCost)
                    Console.WriteLine($"Yes! You have {(left - ticketCost):f2} leva left.");
                else if (ticketCost > left)
                    Console.WriteLine($"Not enough money! You need {(ticketCost - left):f2} leva.");

            }

        }
    }
}
