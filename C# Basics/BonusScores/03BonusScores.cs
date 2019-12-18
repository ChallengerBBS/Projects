using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusScores
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double bonus = 0;
          
            if (num <= 100)
                bonus = 5;
            else if (num <= 1000)
                bonus = num * 0.2;
            else if (num > 1000)
                bonus = num * 0.1;
            if (num % 2 == 0)
                bonus = bonus + 1;
            else if (num % 5 == 0)
                bonus = bonus + 2;

            Console.WriteLine(bonus);
            Console.WriteLine(num+bonus);
        }
    }
}
