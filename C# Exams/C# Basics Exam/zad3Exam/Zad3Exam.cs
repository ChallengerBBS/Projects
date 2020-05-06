using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            var type = Console.ReadLine();
            var feedback = Console.ReadLine();
            int nights = days - 1;
            double totalPrice = 0d;
            if (type == "room for one person")
            {
                totalPrice = nights * 18;
                if (feedback == "positive")
                    totalPrice += (totalPrice * 0.25);
                else if (feedback == "negative")
                    totalPrice -= (totalPrice * 0.1);
            }
            else if (type== "apartment")
            {
                totalPrice = nights * 25;
                if (nights <= 10)
                    totalPrice -= (totalPrice * 0.3);
                else if (nights<=15)
                    totalPrice -= (totalPrice * 0.35);
                else if (nights > 15)
                    totalPrice -= (totalPrice * 0.5);
                if (feedback == "positive")
                    totalPrice += (totalPrice * 0.25);
                else if (feedback == "negative")
                    totalPrice -= (totalPrice * 0.1);
            }
            else if (type== "president apartment")
            {
                totalPrice = nights * 35;
                if (nights <= 10)
                    totalPrice -= (totalPrice * 0.1);
                else if (nights <= 15)
                    totalPrice -= (totalPrice * 0.15);
                else if (nights > 15)
                    totalPrice -= (totalPrice * 0.2);
                if (feedback == "positive")
                    totalPrice += (totalPrice * 0.25);
                else if (feedback == "negative")
                    totalPrice -= (totalPrice * 0.1);
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
