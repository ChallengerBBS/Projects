using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusScores
{
    class Program
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
