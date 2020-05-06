using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace _07_CharExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            
            String[] explosion = Console.ReadLine().Split('>');

            int explosionStrength = 0;
            int remainingExplosionStrength = 0;
            for (int i = 1; i < explosion.Length; i++)
            {
                explosionStrength = int.Parse("" + explosion[i][0]) + remainingExplosionStrength;
                remainingExplosionStrength = explosionStrength - explosion[i].Length;

                if (explosionStrength > explosion[i].Length)
                    explosionStrength = explosion[i].Length;

                explosion[i] = explosion[i].Substring(explosionStrength);
                if (remainingExplosionStrength < 0)
                    remainingExplosionStrength = 0;
            }

            String result = String.Join(">", explosion);
            Console.WriteLine(result);
        }
    }
}