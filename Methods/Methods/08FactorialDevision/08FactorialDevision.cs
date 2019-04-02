using System;

namespace _08FactorialDevision
{
    class Program
    {
        static void Main(string[] args)

        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine($"{FactorialSumOfNumbers(firstNumber, secondNumber):F2}");
        }

        private static double FactorialSumOfNumbers(int firstNumber, int secondNumber)
        {
            double firstFactorial = 1;
            double secondFactorial = 1;
            for (int i = 2; i <= firstNumber; i++)
            {
                firstFactorial *= i;
            }
            for (int i = 2; i <= secondNumber; i++)
            {
                secondFactorial *= i;
            }
            return firstFactorial / secondFactorial;
        }
    }
}
