using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1December
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double max = double.Parse(Console.ReadLine());
            double counter = 0;

            for (int A = 35; A <= 55; A++)
            {
                for (int B = 64; B <= 96; B++)
                {
                    for (int x = 1; x <= a; x++)
                    {
                        for (int y = 1; y <= b; y++)
                        {
                            counter++;
                            Console.Write($"{(char)A}{(char)B}{x}{y}{(char)B}{(char)A}|");

                            A++;
                            B++;

                            if (A > 55)
                            {
                                A = 35;
                            }
                            if (B > 96)
                            {
                                B = 64;
                            }

                            if (x == a && y == b)
                            {
                                return;
                            }
                            if (counter >= max)
                            {
                                return;
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}