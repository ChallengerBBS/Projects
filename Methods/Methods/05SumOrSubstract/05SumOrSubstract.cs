using System;

namespace _05SumOrSubstract
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int sumOfTwoNumbers = SumOfFirstAndSecondNumber(firstNumber, secondNumber);
            
            Console.WriteLine(SubtractThirdFromSumOfFirstTwoNumbers(thirdNumber, sumOfTwoNumbers));
        }

        private static int SubtractThirdFromSumOfFirstTwoNumbers(int thirdNumber, int sumOfTwoNumbers)
        {
            return sumOfTwoNumbers - thirdNumber;
        }

        private static int SumOfFirstAndSecondNumber(int firstNumber, int secondNumber)
        {

            return firstNumber + secondNumber;
        }
    }
}
