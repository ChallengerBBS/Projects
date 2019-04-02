using System;

namespace Methods
{
    class Program
        
    {
        

        
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            switch (command.ToLower())
            {
                case "add":
                    {
                        Console.WriteLine(Add(firstNumber, secondNumber));
                        break;
                    }
                case "subtract":
                    {
                        Console.WriteLine(Subtract(firstNumber, secondNumber));
                        break;
                    }
                case "multiply":
                    {
                        Console.WriteLine(Multiply(firstNumber, secondNumber));
                        break;
                    }
                case "divide":
                    {
                        Console.WriteLine(Divide(firstNumber, secondNumber));
                        break;
                    }
            }
        }

        private static int Divide(int firstNumber, int secondNumber)
        {
            int result = firstNumber / secondNumber;
            return result;
        }

        private static int Multiply(int firstNumber, int secondNumber)
        {
            int result = firstNumber * secondNumber;
            return result;
        }

        private static int Subtract(int firstNumber, int secondNumber)
        {
            int result = firstNumber - secondNumber;
            return result;
        }

        private static int Add(int firstNumber, int secondNumber)
        {
            int result = firstNumber +secondNumber;
            return result;
        }
    }
}
