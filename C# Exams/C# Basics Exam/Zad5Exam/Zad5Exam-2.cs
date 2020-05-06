using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad5Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int projectParts = int.Parse(Console.ReadLine());
            double prizePerPoint = double.Parse(Console.ReadLine());
            int totalPoints = 0;
            for (int i = 1; i <=projectParts; i++)
            {
                int points = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                    points *= 2;
                totalPoints += points;
            }
            double reward = prizePerPoint * totalPoints;
            Console.WriteLine($"The project prize was {reward:f2} lv.");
        }
    }
}
