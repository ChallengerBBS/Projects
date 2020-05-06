using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int runner1 = int.Parse(Console.ReadLine());
            int runner2 = int.Parse(Console.ReadLine());
            int runner3 = int.Parse(Console.ReadLine());
            int runSum = runner1 + runner2 + runner3;
            if (runSum <= 59)
            {
                if (runSum <= 9)
                    Console.WriteLine($"0:0{runSum}");
                else
                    Console.WriteLine($"0:{runSum}");
            }

            else if (runSum <= 119)
            { 
                runSum = runSum - 60;
            
                if (runSum <= 9)
                    Console.WriteLine($"1:0{runSum}");
                else Console.WriteLine($"1:{runSum}");
            } 
            else if (runSum <= 179)
            { 
                runSum = runSum - 120;
            
                if (runSum <= 9)
                    Console.WriteLine($"2:0{runSum}");
                else
                    Console.WriteLine($"2:{runSum}");
            }
        


        }
    }
}
