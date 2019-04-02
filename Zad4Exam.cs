using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 5364;
            int day = 1;
            while (day <= 5)
            {
                string command = Console.ReadLine();
                if (command == "END") break;
                if (command == "Yes") day++;
                if (day > 5) break;
                int m = int.Parse(Console.ReadLine());
                sum += m;
                if (sum >= 8848) break;
            }
            if (sum >= 8848) Console.WriteLine("Goal reached for {0} days!", day);
            else if (sum < 8848)
            {
                Console.WriteLine("Failed!");
                Console.WriteLine(sum);
            }
        }
    }
}