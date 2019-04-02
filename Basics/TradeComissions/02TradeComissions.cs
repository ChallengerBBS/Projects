using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeComissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine().ToLower();
            int sales = int.Parse(Console.ReadLine());
            double com = -1;
            
            if (town == "sofia") 
            {
                if (0 <= sales && sales <= 500) com = 0.05;
                else if (500 < sales && sales <= 1000) com = 0.07;
                else if (1000 < sales && sales <= 10000) com = 0.08;
                else if (sales > 10000) com = 0.12;
            }
            else if (town == "varna")
            {
                if (0 <= sales && sales <= 500) com = 0.045;
                else if (500 < sales && sales <= 1000) com = 0.075;
                else if (1000 < sales && sales <= 10000) com = 0.1;
                else if (sales > 10000) com = 0.13;
            }
            else if (town == "plovdiv")
            {
                if (0 <= sales && sales <= 500) com = 0.055;
                else if (500 < sales && sales <= 1000) com = 0.08;
                else if (1000 < sales && sales <= 10000) com = 0.12;
                else if (sales > 10000) com = 0.145;
            }
            
            double total = sales * com;
            if (com > 0)
                Console.WriteLine($"{total:f2}");
            else
                Console.WriteLine("error");




        }
    }
}
