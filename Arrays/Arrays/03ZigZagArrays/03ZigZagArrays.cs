using System;
using System.Linq;

namespace _03ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] leftToRightDiagonal = new int[count];
            int[] rightToLeftDiagonal = new int[count];
                  

            for (int i = 0; i < count; i++)
            {
                int[] currentArray = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                if (i%2==0)
                {
                    leftToRightDiagonal[i] = currentArray[0];
                    rightToLeftDiagonal[i] = currentArray[1];
                }
                else
                {
                    {
                        leftToRightDiagonal[i] = currentArray[1];
                        rightToLeftDiagonal[i] = currentArray[0];
                    }
                }
            }
            Console.WriteLine(String.Join(" ", leftToRightDiagonal));
        }
    }
}
