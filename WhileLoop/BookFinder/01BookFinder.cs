using System;

namespace upr5zad8Sequence2k_1
{
    class upr5zad8
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = 1;
            while
            (k <= n)
            {
                Console.WriteLine(k);
                k =( 2 * k )+ 1;
            }
        }
    }
}