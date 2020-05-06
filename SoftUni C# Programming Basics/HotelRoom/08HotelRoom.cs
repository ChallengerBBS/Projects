using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine()
            .ToLower()
            .Trim();

            int nights = int.Parse(Console.ReadLine());

            double priceStudio = 0d;
            double priceApartment = 0d;

            if (month == "may" || month == "october")
            {
                priceStudio = 50;
                priceApartment = 65;

                if (nights >= 0 && nights < 8)
                {
                    Console.WriteLine("Apartment: " + $"{(nights * priceApartment):F2}" + " lv.");
                    Console.WriteLine("Studio: " + $"{(nights * priceStudio):F2}" + " lv.");
                }
                else if (nights > 7 && nights < 15)
                {
                    double discountStudio = priceStudio - (priceStudio * 0.05);

                    Console.WriteLine("Apartment: " + $"{(nights * priceApartment):F2}" + " lv.");
                    Console.WriteLine("Studio: " + $"{(nights * discountStudio):F2}" + " lv.");
                }
                else // pove4e ot 14
                {
                    double discountStudio = priceStudio - (priceStudio * 0.3);
                    double discountApartment = priceApartment - (priceApartment * 0.1);

                    Console.WriteLine("Apartment: " + $"{(nights * discountApartment):F2}" + " lv.");
                    Console.WriteLine("Studio: " + $"{(nights * discountStudio):F2}" + " lv.");
                }

            }
            else if (month == "june" || month == "september")
            {
                priceStudio = 75.20;
                priceApartment = 68.70;

                if (nights >= 0 && nights < 15)
                {
                    Console.WriteLine("Apartment: " + $"{(nights * priceApartment):F2}" + " lv.");
                    Console.WriteLine("Studio: " + $"{(nights * priceStudio):F2}" + " lv.");
                }
                else // pove4e ot 14
                {
                    double discountStudio = priceStudio - (priceStudio * 0.2);
                    double discountApartment = priceApartment - (priceApartment * 0.1);

                    Console.WriteLine("Apartment: " + $"{(nights * discountApartment):F2}" + " lv.");
                    Console.WriteLine("Studio: " + $"{(nights * discountStudio):F2}" + " lv.");
                }

            }
            else if (month == "july" || month == "august")
            {
                priceStudio = 76;
                priceApartment = 77;

                if (nights >= 0 && nights < 15)
                {
                    Console.WriteLine("Apartment: " + $"{(nights * priceApartment):F2}" + " lv.");
                    Console.WriteLine("Studio: " + $"{(nights * priceStudio):F2}" + " lv.");
                }
                else // pove4e ot 14
                {
                    double discountApartment = priceApartment - (priceApartment * 0.1);

                    Console.WriteLine("Apartment: " + $"{(nights * discountApartment):F2}" + " lv.");
                    Console.WriteLine("Studio: " + $"{(nights * priceStudio):F2}" + " lv.");
                }
            }

        }
    }
}