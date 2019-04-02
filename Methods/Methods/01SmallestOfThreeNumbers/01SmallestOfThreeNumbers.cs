using System;

namespace _01SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            Console.WriteLine(SmallestNumber(firstNumber,secondNumber,thirdNumber));
        }
        static int SmallestNumber (int firstNumber, int secondNumber, int thirdNumber)
        {
            if (firstNumber<secondNumber&& firstNumber<thirdNumber)
            {
                return firstNumber;
            }
            else if (firstNumber > secondNumber && secondNumber < thirdNumber)
            {
                return secondNumber;
            }
            else 
            {
                return thirdNumber;
            }
        }
    }
}

