using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancinHall
{
    class DancingHall
    {
        static void Main(string[] args)
        {
            double L = double.Parse(Console.ReadLine());
            double W = double.Parse(Console.ReadLine());
            double A = double.Parse(Console.ReadLine());
            double Hall = (L * 100) * (W * 100);
            double Ward = (A * 100 * A * 100);
            double Bench = (Hall / 10);
            double freeSpc = Hall - Bench - Ward;
            double dancersCount = freeSpc / (40 + 7000);
            Console.WriteLine(Math.Floor(dancersCount));
        }

    }
}
