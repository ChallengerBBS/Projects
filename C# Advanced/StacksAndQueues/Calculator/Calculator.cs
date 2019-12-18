using System;
using System.Collections.Generic;
using System.Linq;

namespace Zad01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            var collector = new Stack<string>(input.Reverse());
           
            while (collector.Count>1)
            {
                int operand1 = int.Parse(collector.Pop());
                string opr = collector.Pop();
                int operand2 = int.Parse(collector.Pop());
                switch(opr)
                {
                    case "+":
                        collector.Push((operand1 + operand2).ToString());
                        break;
                    case "-":
                        collector.Push((operand1 - operand2).ToString());
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(collector.Pop());
        }
    }
}
