using System;
using System.Linq;

namespace _02CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine()
                .Split(" ");
            string[] secondArray = Console.ReadLine()
                .Split(" ");
            
            for (int i = 0; i < firstArray.Length; i++)
            {
                for (int j = 0; j < secondArray.Length; j++)
                {
                    if (secondArray[j]==firstArray[i])
                    {
                        Console.Write(secondArray[j] + " ");
                    }
                }

            }

            Console.WriteLine();
        }
    }
}
