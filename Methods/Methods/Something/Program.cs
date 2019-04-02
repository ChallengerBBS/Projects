using System;

namespace Something
{
    class Program
    {
        static Random rndm = new Random();
        static void Main(string[] args)
        {
            while (true)
            {
                
                
                if (Console.ReadKey().Key == ConsoleKey.G)
                {
                    Console.Clear();
                    Generate();
                    Console.WriteLine();
                }
                else if (Console.ReadKey().Key == ConsoleKey.E)
                {
                    Console.Clear();
                    Console.WriteLine("Exiting program...");
                    Console.WriteLine();
                }
                
            }
            


        }
        static void Generate()
        {
            int number = rndm.Next(1, 25);
            Console.WriteLine(number);
        }

    }
}
