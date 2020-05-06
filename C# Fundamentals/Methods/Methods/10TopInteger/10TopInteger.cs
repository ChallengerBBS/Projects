using System;

namespace _10TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int number = 1; number <= n; number++)
            {
                if (IsSumOfDigitsDevisibleByEight(number) && AtLeastOneOddDigit(number))
                {
                    Console.WriteLine(number);
                }
            }
        }

        private static bool AtLeastOneOddDigit(int number)
        {

            while (number >= 1)
            {
                int digit = number % 10;
                number = number / 10;
                if (digit % 2 != 0)
                {
                    return true;
                }

            }
            return false;

        }

        private static bool IsSumOfDigitsDevisibleByEight(int number)
        {
            int sumOfDigits = 0;

            while (number >= 1)
            {
                int digit = number % 10;
                sumOfDigits += digit;
                number = number / 10;
            }

            if (sumOfDigits % 8 == 0)
            {
                return true;
            }

            return false;


        }
    }
}