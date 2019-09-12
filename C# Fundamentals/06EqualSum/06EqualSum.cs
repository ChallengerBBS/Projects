using System;
using System.Linq;

namespace _06EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            if (inputNumbers.Length == 1)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                int sumLeft = 0;
                int sumRight = 0;
                for (int indexOfLeftNumbers = 0; indexOfLeftNumbers < i; indexOfLeftNumbers++)
                {
                        sumLeft += inputNumbers[indexOfLeftNumbers];
                }
                for (int indexOfRightNumbers = i+1; indexOfRightNumbers < inputNumbers.Length; indexOfRightNumbers++)
                {                 
                        sumRight += inputNumbers[indexOfRightNumbers];     
                }

                if (sumLeft == sumRight)
                {
                    Console.WriteLine(i);
                    return;
                }

            }

            Console.WriteLine("no");

        }
    }
}