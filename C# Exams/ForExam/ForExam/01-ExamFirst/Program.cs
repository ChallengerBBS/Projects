using System;
using System.Collections.Generic;
using System.Linq;
namespace _01_ExamFirst
{
    class Exam01
    {
        static void Main(string[] args)
        {
            double adventureDays = double.Parse(Console.ReadLine());
            double playersCount = double.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerPerson = double.Parse(Console.ReadLine());
            double foodPerPerson = double.Parse(Console.ReadLine());
            double totalWater = waterPerPerson * adventureDays * playersCount;
            double totalFood = foodPerPerson * adventureDays * playersCount;
            double energyLoss = 0;
            for (double currentDay = 1; currentDay <= adventureDays; currentDay++)
            {
                energyLoss = double.Parse(Console.ReadLine());
                groupEnergy -= energyLoss;
                if (currentDay % 2.0 == 0d)
                {
                    groupEnergy += (groupEnergy * 0.05);
                    totalWater -= (totalWater * 0.3);
                }
                if (currentDay % 3.0 == 0d)
                {
                    totalFood -= (totalFood / playersCount);
                    groupEnergy += (groupEnergy * 0.1);
                }
                if (groupEnergy <= 0d)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    return;
                }

            }
            if (groupEnergy > 0d)
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");

        }
    }
}
