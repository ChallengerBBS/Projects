using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            var resourceQnty = new Dictionary<string, int>();
            while ((input = Console.ReadLine()) != "stop")
            {
                int qnty = int.Parse(Console.ReadLine());

                if (resourceQnty.ContainsKey(input))
                {
                    resourceQnty[input] += qnty;
                }
                else
                {
                    resourceQnty.Add(input, qnty);
                }

            }
            foreach (var res in resourceQnty)
            {
                Console.WriteLine(res.Key + " -> " + res.Value);
            }

        }
    }
}
