using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int alpinist = int.Parse(Console.ReadLine());
            int carabiniers = int.Parse(Console.ReadLine());
            int ties = int.Parse(Console.ReadLine());
            int pikkels = int.Parse(Console.ReadLine());
            int priceCar = carabiniers * 36;
            double priceTies = ties * 3.6;
            double pricePik = pikkels * 19.80;
            double priceTotal = (priceCar + priceTies + pricePik) * alpinist;
            priceTotal += (priceTotal * 0.2);
            Console.WriteLine($"{priceTotal:f2}");
        }
    }
}
