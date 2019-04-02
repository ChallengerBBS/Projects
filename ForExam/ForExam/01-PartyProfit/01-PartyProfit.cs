using System;
namespace _01_PartyProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int coins = 0;
            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                if (currentDay%10==0)
                {
                    partySize -= 2;
                }
                if (currentDay%15==0)
                {
                    partySize += 5;
                }
                coins += 50;
                coins -= 2 * partySize;

                if (currentDay % 3 == 0)
                    coins -= 3 * partySize;
                if (currentDay % 5 == 0)
                {
                    if (currentDay % 3 == 0)
                        coins -= 2 * partySize;

                    coins += 20 * partySize;
                }

            
            }
            Console.WriteLine($"{partySize} companions received {coins/partySize} coins each.");
        }
    }
}
