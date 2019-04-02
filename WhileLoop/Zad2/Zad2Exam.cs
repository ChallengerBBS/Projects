using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            double widht = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double passengerH = double.Parse(Console.ReadLine());
            double spaceArea = widht * lenght * height;
            double roomArea = (passengerH + 0.4) * 2 * 2;
            double space = spaceArea / roomArea;
            if (space<3)
                Console.WriteLine("The spacecraft is too small.");
            else if(space>10)
                Console.WriteLine("The spacecraft is too big.");
            else
                Console.WriteLine($"The spacecraft holds {Math.Floor(space)} astronauts.");
        }
    }
}
