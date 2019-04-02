using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZsd
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
                Console.WriteLine("Enter your value: ");
                double value = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter your input currency: ");
                string InputCurr = Console.ReadLine();
                Console.WriteLine("Enter your out currency: ");
                string OutputCurr = Console.ReadLine();
                double lev = 1.0;
                double usd = 1.79549;
                double eur = 1.95583;
                double gbp = 2.53405;
                switch (InputCurr)
                {
                    case "BGN":
                        value = (value * lev); break;
                    case "USD":
                        value = (value * usd); break;
                    case "EUR":
                        value = (value * eur); break;
                    case "GBP":
                        value = (value * gbp); break;
                }
                switch (OutputCurr)
                {
                    case "BGN":
                        value = (value / lev); break;
                    case "USD":
                        value = (value / usd); break;
                    case "EUR":
                        value = (value / eur); break;
                    case "GBP":
                        value = (value / gbp); break;
                }

                Console.WriteLine("{0}" + " " + OutputCurr, value);
            
            
   
        }

    }
}
