using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_sum_Left_Right_position
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int i = num1; i <= num2; i++)
            {
                int currentNum = i;
                int leftSum = 0;
                int rightSum = 0;
                int midNum = 0;
                for (int r = 1; r <= 2; r++)
                {
                    rightSum += currentNum % 10;
                    currentNum /= 10;
                }
                midNum += currentNum % 10;
                currentNum /= 10;
                for (int l = 4; l <= 5; l++)
                {
                    leftSum += currentNum % 10;
                    currentNum /= 10;
                }
                if (rightSum > leftSum)
                {
                    leftSum += midNum;
                }
                else if (leftSum > rightSum)
                {
                    rightSum += midNum;
                }

                if (rightSum == leftSum)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
