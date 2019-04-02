using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourexam = int.Parse(Console.ReadLine());
            int minexam = int.Parse(Console.ReadLine());
            int hourarrival = int.Parse(Console.ReadLine());
            int minarrival = int.Parse(Console.ReadLine());

            hourexam = 60 * hourexam;
            minexam = minexam + hourexam;

            hourarrival = 60 * hourarrival;
            minarrival = minarrival + hourarrival;

            int time = minarrival - minexam;
            int hours = 0;

            if (time > 0)
                Console.WriteLine("Late");
            if (time < -30)
                Console.WriteLine("Early");
            else if (time <= 0)
                Console.WriteLine("On time");

            if (time < 0 & time > -60)
                Console.WriteLine("{0} minutes before the start", Math.Abs(time));


            if (time <= -60)
            {
                while (time <= -60)
                {
                    hours++;
                    time = time + 60;
                }
                if (time > -10)
                    Console.WriteLine("{0}:0{1} hours before the start", hours, Math.Abs(time));
                else if (time <= -10)
                    Console.WriteLine("{0}:{1} hours before the start", hours, Math.Abs(time));

            }
            if (time > 0 & time < 60)
                Console.WriteLine("{0} minutes after the start", (time));

            if (time >= 60)
            {
                while (time >= 60)
                {
                    hours++;
                    time = time - 60;
                }
                if (time < 10)
                    Console.WriteLine("{0}:0{1} hours after the start", hours, time);
                else if (time >= 10)
                    Console.WriteLine("{0}:{1} hours after the start", hours, (time));
            }






        }
    }
}