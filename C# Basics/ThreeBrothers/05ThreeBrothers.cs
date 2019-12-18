using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBrothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double bro1 = double.Parse(Console.ReadLine());
double bro2 = double.Parse(Console.ReadLine());
        

            double bro3 = double.Parse(Console.ReadLine());
            double father = double.Parse(Console.ReadLine());
            
            double time = 1 / ((1 / bro1) + (1 / bro2) + (1 / bro3));
            time = time + (time * 0.15);

            if (time < father)
            {
                Console.WriteLine($"Cleaning time: {time:F2}");
                time = father - time;

                Console.WriteLine("Yes, there is a surprise - time left -> " + Math.Floor(time) + " hours.");
            }
            else if (time>father)
            {
                Console.WriteLine($"Cleaning time: {time:F2}");
                time = time - father;
                Console.WriteLine("No, there isn't a surprise - shortage of time -> "+Math.Ceiling(time)+" hours.");
            }




        }
    }
}
