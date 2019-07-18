using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesChooser
{
    class Program
    {
        static void Main(string[] args)
        {
            int temperature = int.Parse(Console.ReadLine());
            string daytime = Console.ReadLine();
            if (10 <= temperature && temperature <= 18)
            {
                if (daytime == "Morning")
                    Console.WriteLine($"It's {temperature} degrees, get your Sweatshirt and Sneakers.");
                else if (daytime=="Afternoon")
                    Console.WriteLine($"It's {temperature} degrees, get your Shirt and Moccasins.");
                else if (daytime == "Evening")
                    Console.WriteLine($"It's {temperature} degrees, get your Shirt and Moccasins.");
            }
            if (18 < temperature && temperature <= 24)
            {
                if (daytime == "Morning")
                    Console.WriteLine($"It's {temperature} degrees, get your Shirt and Moccasins.");
                else if (daytime == "Afternoon")
                    Console.WriteLine($"It's {temperature} degrees, get your T-Shirt and Sandals.");
                else if (daytime == "Evening")
                    Console.WriteLine($"It's {temperature} degrees, get your Shirt and Moccasins.");
            }
            if (25<=temperature)
            {
                if (daytime == "Morning")
                    Console.WriteLine($"It's {temperature} degrees, get your T-Shirt and Sandals.");
                else if (daytime == "Afternoon")
                    Console.WriteLine($"It's {temperature} degrees, get your Swim Suit and Barefoot.");
                else if (daytime == "Evening")
                    Console.WriteLine($"It's {temperature} degrees, get your Shirt and Moccasins.");
            }
        }
    }
}
