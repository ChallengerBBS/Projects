using System;

namespace _07NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            CreateMatrixOfNumbers(input);
        }

        private static void CreateMatrixOfNumbers(int input)
        {
            for (int i = 0; i < input; i++)
            {
                for (int j = 0; j < input; j++)
                {
                    Console.Write(input+" ");
                    
                }
                Console.WriteLine();
            }
        }
    }
}
