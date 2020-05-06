using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = new StringBuilder();
            firstNumber.Append(Console.ReadLine()); 
            int secondNumber = int.Parse(Console.ReadLine());
            int addingNumber = 0;
            int numberInMind = 0;
            var result = new List<int>();
            if (secondNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }
            for (int i = firstNumber.Length-1; i >=0 ; i--)
            {
                
                int currentNumber = firstNumber[i] - '0';
                currentNumber *= secondNumber;
                currentNumber += numberInMind;
                addingNumber = currentNumber % 10;
                numberInMind = currentNumber / 10;
                result.Add(addingNumber);
            }
            if (numberInMind>0)
            {
                result.Add(numberInMind);
            }
            result.Reverse();
            Console.WriteLine(string.Join("", result));



        }
    }
}
