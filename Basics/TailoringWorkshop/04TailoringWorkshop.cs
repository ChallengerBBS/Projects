using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailoringWorkshop
{
    class TailoringWorkshop
    {
        static void Main(string[] args)
        {
            double count = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double TableCloth = count * (lenght + 2 * 0.30) * (width + 2 * 0.30);
            double SquareTableCloth = count * (lenght /2) * (lenght /2);
            double PriceUSD = (TableCloth * 7) + (SquareTableCloth * 9);
            double PriceBGN = PriceUSD * 1.85;
            Console.WriteLine("{0:F2} USD",PriceUSD);
            Console.WriteLine("{0:F2} BGN",PriceBGN);

        }
    }
}
