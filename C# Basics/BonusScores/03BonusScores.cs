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
<<<<<<< HEAD
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
=======
            double num = double.Parse(Console.ReadLine());
            double bonus = 0;
          
            if (num <= 100)
                bonus = 5;
            else if (num <= 1000)
                bonus = num * 0.2;
            else if (num > 1000)
                bonus = num * 0.1;
            if (num % 2 == 0)
                bonus = bonus + 1;
            else if (num % 5 == 0)
                bonus = bonus + 2;

            Console.WriteLine(bonus);
            Console.WriteLine(num+bonus);
>>>>>>> 51d712d9ebfe9cd9b58ebb12fc31d499e3f6c843
        }
    }
}
