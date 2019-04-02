using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    class Program
    {
        static void Main(string[] args)
        {
            int hh = int.Parse(Console.ReadLine());
            int mm = int.Parse(Console.ReadLine());
            mm = mm + 15;
            if (mm > 59)
            {
                hh = hh + 1;
                mm = mm - 60;
            }
            if (hh > 23)
                hh = 0;
            if (mm<=9)
                Console.WriteLine(hh+":"+"0"+mm);
            else
                Console.WriteLine(hh+":"+mm);

        }
    }
}
