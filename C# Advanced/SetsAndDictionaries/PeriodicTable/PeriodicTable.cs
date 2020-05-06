using System;
using System.Linq;
using System.Collections.Generic;


namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var chemTable = new HashSet<string>();
            for (int i = 0; i < count; i++)
            {
                string[] username = Console.ReadLine().Split();
                for (int j = 0; j < username.Length; j++)
                {
                    if (!chemTable.Contains(username[j]))
                    {
                        chemTable.Add(username[j]);
                    }
                }
                
            }
            foreach (var chemCompound in chemTable.OrderBy(x=>x))
            {
                Console.Write(chemCompound+" ");
            }
            Console.WriteLine();
        }
    }
}
