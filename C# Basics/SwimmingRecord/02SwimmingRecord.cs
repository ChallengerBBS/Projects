using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double metres = double.Parse(Console.ReadLine());
            double speed = double.Parse(Console.ReadLine());
            double time = metres * speed;
            double slowdown = Math.Floor(metres / 15) * 12.5;
            double totalTime = time + slowdown;
            double timeLeft =  totalTime-record ;
            if (totalTime >= record)
                Console.WriteLine($"No, he failed! He was {timeLeft:F2} seconds slower.");
            else if (totalTime < record)
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:F2} seconds.");
           
        }
    }
}
