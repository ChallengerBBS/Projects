using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftRightSum
{
    class LeftRightSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;
            for (int i = 1; i <= n; i++)
            {
                leftSum += int.Parse(Console.ReadLine());

            }
            for (int i = 1; i <= n; i++)
            {
                rightSum += int.Parse(Console.ReadLine());
            }
            int differens = Math.Abs( leftSum - rightSum);

            if (differens == 0)
            { Console.WriteLine($"Yes, sum = {leftSum}"); }
            else
            { Console.WriteLine($"No, diff = {differens}" ); }

            //int n = int.Parse(Console.ReadLine());
            //int leftSum = 0;
            //for (int i = 1; i <= n; i++)
            //{
            //    leftSum = leftSum + int.Parse(Console.ReadLine());
            //}
            //int rightSum = 0;
            //for (int i = 1; i <= n; i++)
            //{
            //    rightSum = rightSum + int.Parse(Console.ReadLine());
            //}
            //if (leftSum == rightSum)
            //    Console.WriteLine("Yes, sum = " + leftSum);
            //else
            //{
            //    double diff = Math.Abs(rightSum - leftSum);

            //    Console.WriteLine("No, diff = " + diff);
            //}

        }
    }
}
