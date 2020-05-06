using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01SumAdjacentOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            //var number = Console.ReadLine().Split().Select(double.Parse).ToList();
            //for (int i = 0; i < number.Count-1; i++)
            //{
            //    if (number[i]==number[i+1])
            //    {
            //        number[i] += number[i + 1];
            //        number.RemoveAt(i+1);
            //        i = -1;
            //    }
            //}
            //Console.WriteLine(String.Join(' ', number));

            var number = Console.ReadLine().Split().Select(int.Parse).ToList();
            for (int i = 0; i < number.Count/2; i++)
            {
                number[i] += number[number.Count  - 1];
                number.RemoveAt(number.Count - 1);
            }
            Console.WriteLine(String.Join(" ", number));

        }
    }
}
