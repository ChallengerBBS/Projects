using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoRepairAndService
{
    class Program
    {
        static void Main(string[] args)
        {
            string country  = Console.ReadLine();

            switch (country)
            {
                case "USA":
                case "England": Console.WriteLine("English"); break;
                default:
                    break;
            }

        }
    }
}