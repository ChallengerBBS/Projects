using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var list = new SortedDictionary<string, List<int>>();
            list["Niki"] = new List<int>();
            list["Niki"].Add(int.Parse(Console.ReadLine()));
            list["Niki"].Add(int.Parse(Console.ReadLine()));
            list["Niki"].Add(int.Parse(Console.ReadLine()));

            foreach (var item in list["Niki"])
            {
                Console.WriteLine(item.Key+" "+item.Value);
            }

        }
    }
   
}
