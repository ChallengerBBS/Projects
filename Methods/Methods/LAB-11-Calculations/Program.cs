using System;

namespace LAB_11_Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(Calculate(firstNumber, operation, secondNumber));
        }

        private static int Calculate(int firstNumber, string operation, int secondNumber)
        {
            int result = 0;
            switch(operation)
            {
                case "+": result = firstNumber + secondNumber;
                    break;
                case "-": result = firstNumber - secondNumber;
                    break;
                case "*": result = firstNumber * secondNumber;
                    break;
                case "/": result = firstNumber / secondNumber;
                    break;
            }
            return result;
        }
    }
}
