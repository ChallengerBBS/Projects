using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB_02_OddOcc
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).Take(3);
            foreach (var item in numbers)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
    }
}
