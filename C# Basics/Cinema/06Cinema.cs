using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            var holidays = double.Parse(Console.ReadLine());
            var weekend = double.Parse(Console.ReadLine());
            var weekendSof = 48 - weekend;
            var gamesSof = weekendSof * (3.0 / 4);
            var holidaysGames = holidays * (2.0 / 3);
            var totalGames = holidaysGames + gamesSof + weekend;
            if (year == "leap")
            {
                totalGames = totalGames + (totalGames * 0.15);
                Console.WriteLine(Math.Truncate(totalGames));
            }
            else if (year == "normal")
                Console.WriteLine(Math.Truncate(totalGames));


        }
    }
}
