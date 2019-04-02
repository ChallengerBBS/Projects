using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int xmasSpirit = 0;
            int ornamentPrice = 2;
            int treeSkirtPrice = 5;
            int treeGarlandsPrice = 3;
            int treeLightsPrice = 15;
            int cost = 0;
            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                if (currentDay % 2 == 0)
                {
                    cost += (ornamentPrice * quantity);
                    xmasSpirit += 5;
                }
                if (currentDay % 3 == 0)
                {
                    cost += (treeGarlandsPrice * quantity);
                    cost += (treeSkirtPrice * quantity);
                    xmasSpirit += 13;
                }
                if (currentDay % 5 == 0)
                {
                    cost += (treeLightsPrice * quantity);
                    xmasSpirit += 17;
                    if (currentDay % 3 == 0)
                    {
                        xmasSpirit += 30;
                    }
                }
                if (currentDay % 10 == 0)
                {
                    xmasSpirit -= 20;
                    cost += treeSkirtPrice + treeLightsPrice + treeGarlandsPrice;
                    quantity += 2;
                }
                

            }
            if (days % 10 == 0)
            {
                xmasSpirit -= 30;
            }
            Console.WriteLine($"Total cost: {cost}");
            Console.WriteLine($"Total spirit: {xmasSpirit}"); 

        }
    }


}
