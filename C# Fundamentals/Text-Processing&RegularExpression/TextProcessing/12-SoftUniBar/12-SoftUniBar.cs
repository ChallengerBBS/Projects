using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _12_SoftUniBar
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"%(?<client>[A-Z][a-z]+)%([^|$.%]*)<(?<product>\w+)>\1*\|(?<count>\d+)\|\1*?(?<price>\d+\.?\d+)\$";
            string commandLine = Console.ReadLine();
            var totalProfit = 0d;
            while (commandLine!="end of shift")
            {
                var validOrder = new Regex(pattern);
                if (validOrder.IsMatch(commandLine))
                {
                    string clientName = validOrder.Match(commandLine).Groups["client"].Value;
                    string product = validOrder.Match(commandLine).Groups["product"].Value;
                    int count = int.Parse(validOrder.Match(commandLine).Groups["count"].Value);
                    var price = double.Parse(validOrder.Match(commandLine).Groups["price"].Value);
                    double totalPrice = price * count;
                    totalProfit += totalPrice;
                    Console.WriteLine($"{clientName}: {product} - {totalPrice:f2}");
                }

                commandLine = Console.ReadLine();

            }
            Console.WriteLine($"Total income: {totalProfit:f2}");
        }
    }
}
