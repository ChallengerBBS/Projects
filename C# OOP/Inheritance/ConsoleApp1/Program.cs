using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = "Brand: {0} Model: {1} has {2} HP";

            Console.WriteLine(string.Format(msg, "Mercedes-Benz", "CL500", "306"));
            Console.WriteLine(string.Format(msg, "BMW", "320i", "150"));
        }
    }
}
