using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskeyPrice = double.Parse(Console.ReadLine());
            double beerQty = double.Parse(Console.ReadLine());
            double wineQty = double.Parse(Console.ReadLine());
            double rakijaQty = double.Parse(Console.ReadLine());
            double whiskeyQty = double.Parse(Console.ReadLine());

            double rakijaPrice = whiskeyPrice / 2;
            double winePrice = rakijaPrice - (rakijaPrice * 0.4);
            double beerPrice = rakijaPrice -(rakijaPrice * 0.8);

            double rakijaSum = rakijaPrice * rakijaQty;
            double wineSum = winePrice * wineQty;
            double whiskeySum = whiskeyPrice * whiskeyQty;
            double beerSum = beerPrice * beerQty;
            double totalSum = beerSum + rakijaSum + wineSum + whiskeySum;

            Console.WriteLine($"{totalSum:F2}");



        }


    }
}
