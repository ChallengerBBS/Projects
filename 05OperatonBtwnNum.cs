using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OperationBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string operatora = (Console.ReadLine());
            double result = 0;
            if (operatora == "+")
            {
                result = n1 + n2;
                if (result % 2 == 0)
                    Console.WriteLine($"{n1} {operatora} {n2} = {result} - even");
                else if (result %2 != 0)
                    Console.WriteLine($"{n1} {operatora} {n2} = {result} - odd");
            }
            else if (operatora == "-")
            {
                result = n1 - n2;
                if (result % 2 == 0)
                    Console.WriteLine($"{n1} {operatora} {n2} = {result} - even");
                else if (result %2 != 0)
                    Console.WriteLine($"{n1} {operatora} {n2} = {result} - odd");
            }
            else if (operatora == "*")
            {
                result = n1 * n2;
                if (result % 2 == 0)
                    Console.WriteLine($"{n1} {operatora} {n2} = {result} - even");
                else if (result %2 != 0)
                    Console.WriteLine($"{n1} {operatora} {n2} = {result} - odd");
            }
            else if (operatora == "/")
            {
                result = n1 / n2;
                if (n2 == 0)
                    Console.WriteLine($"Cannot divide {n1} by zero");
                else
                    Console.WriteLine($"{n1} / {n2} = {result:f2}");
            }
            else if (operatora == "%")
            {
                result = n1 % n2;
                if (n2 == 0)
                    Console.WriteLine($"Cannot divide {n1} by zero");
                else if (n2!=0)
                Console.WriteLine($"{n1} % {n2} = {result}");

            }
        }
    }
}
