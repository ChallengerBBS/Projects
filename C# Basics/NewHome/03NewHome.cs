using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHome
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            double count = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double totalPrice = 0;
            if (type == "Roses")
            {
                totalPrice = count * 5;
                if (count > 80)
                    totalPrice = totalPrice - (totalPrice * 0.1);
            }
            else if (type == "Dahlias")
            {
                totalPrice = count * 3.8;
                if (count > 90)
                    totalPrice = totalPrice - (totalPrice * 0.15);
            }
            else if (type == "Tulips")
            {
                totalPrice = count * 2.8;
                if (count > 80)
                    totalPrice = totalPrice - (totalPrice * 0.15);
            }
            else if (type == "Narcissus")
            {
                totalPrice = count * 3;
                if (count < 120)
                    totalPrice = totalPrice + (totalPrice * 0.15);
            }
            else if (type == "Gladiolus")
            {
                totalPrice = count * 2.5;
                if (count < 80)
                    totalPrice = totalPrice + (totalPrice * 0.2);
            }
            if (budget>=totalPrice)
                Console.WriteLine($"Hey, you have a great garden with {count} {type} and {(budget-totalPrice):f2} leva left."
);
            else if (budget<totalPrice)
                Console.WriteLine($"Not enough money, you need {(totalPrice-budget):f2} leva more.");
        }
    }
}
