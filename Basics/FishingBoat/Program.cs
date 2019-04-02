using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double count = double.Parse(Console.ReadLine());
            double boatPrice = 0;
            if (season == "Spring")
            {
                boatPrice = 3000;
                if (count <= 6)
                    boatPrice = boatPrice - (boatPrice * 0.1);
                else if (7 < count && count <= 11)
                    boatPrice = boatPrice - (boatPrice * 0.15);
                else if (count > 12.0)
                    boatPrice = boatPrice - (boatPrice * 0.25);
            }
            else if (season == "Summer" || season == "Autumn")
            {
                boatPrice = 4200;
                if (count <= 6)
                    boatPrice = boatPrice - (boatPrice * 0.1);
                else if (7 < count && count <= 11)
                    boatPrice = boatPrice - (boatPrice * 0.15);
                else if (count > 12)
                    boatPrice = boatPrice - (boatPrice * 0.25);
            }
            else if (season == "Winter")
            {
                boatPrice = 2600;
                if (count <= 6)
                    boatPrice = boatPrice - (boatPrice * 0.1);
                else if (7 < count && count <= 11)
                    boatPrice = boatPrice - (boatPrice * 0.15);
                else if (count > 12)
                    boatPrice = boatPrice - (boatPrice * 0.25);
            }
            if (count % 2== 0 && season != "Autumn")
                boatPrice = boatPrice - (boatPrice * 0.05);
            if (budget >= boatPrice)
                Console.WriteLine($"Yes! You have {(budget - boatPrice):f2} leva left.");
            else if (budget < boatPrice)
                Console.WriteLine($"Not enough money! You need {(boatPrice - budget):f2} leva.");

        }
    }
}
