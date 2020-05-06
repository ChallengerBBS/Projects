using System;
using Vehicles.Models;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(maxfactor(20));


        }

        static private long maxfactor(long n)
        {
            long k = 2;
            while (k * k <= n)
            {
                if (n % k == 0)
                {
                    n /= k;
                }
                else
                {
                    ++k;
                }
            }

            return n;
        }
    }
}

