using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityCampaign
{
    class Charity
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int cookers = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int gaufrettes = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());
            double cakeSum = cakes * 45;
            double gauSum = gaufrettes * 5.80;
            double panSum = pancakes * 3.20;
            double totalSum = (cakeSum + gauSum + panSum) * cookers;
            double campaignSum = totalSum * days;
            double netSum = campaignSum - (campaignSum / 8);
            Console.WriteLine($"{netSum:F2}");

        }
    }
}
