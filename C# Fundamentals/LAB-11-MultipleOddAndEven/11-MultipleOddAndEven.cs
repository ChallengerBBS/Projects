using System;

namespace LAB_11_MultipleOddAndEven
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            Console.WriteLine(MultipleOfEachSumOddAndEven(SumOfOddNumbers(number), SumOfEvenNumbers(number)));

        }

        private static int MultipleOfEachSumOddAndEven(int v1, int v2)
        {
            int result = v1 * v2;
            return result;
        }

        private static int SumOfOddNumbers(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                int digit = number % 10;
                if (digit % 2 != 0)
                {
                    sum += digit;
                }
                number /= 10;
            }
            return sum;
        }

        private static int SumOfEvenNumbers(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                int digit = number % 10;
                if (digit % 2 == 0)
                {
                    sum += digit;
                }
                number /= 10;
            }
            return sum;
        }
    }
}
