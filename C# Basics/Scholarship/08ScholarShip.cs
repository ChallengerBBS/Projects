using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double success = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());
            double socScholarship = 0;
            double sucScholarship = 0;
            if (income < minSalary && success > 4.5)
                socScholarship = minSalary * 0.35;
            if (success >= 5.5)
                sucScholarship = success * 25;

            if (socScholarship > sucScholarship)
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socScholarship)} BGN");
            else if (sucScholarship>=socScholarship && sucScholarship>0 )
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(sucScholarship)} BGN");
            else
                Console.WriteLine("You cannot get a scholarship!");




        }
    }
}
