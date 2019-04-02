using System;
using System.Linq;

namespace _06CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPlayerCards = Console.ReadLine().Split().Select(int.Parse).ToList();
            var secondPlayerCards = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sumPoints = 0;
            while (firstPlayerCards.Count != 0 && secondPlayerCards.Count != 0)
            {

                if (firstPlayerCards[0] > secondPlayerCards[0])
                {
                    firstPlayerCards.Add(firstPlayerCards[0]);
                    firstPlayerCards.Add(secondPlayerCards[0]);
                }
                else if (secondPlayerCards[0] > firstPlayerCards[0])
                {
                    secondPlayerCards.Add(secondPlayerCards[0]);
                    secondPlayerCards.Add(firstPlayerCards[0]);
                }
                
                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);

                if (firstPlayerCards.Count == 0 && secondPlayerCards.Count == 0)
                {
                    Console.WriteLine("There is no winner !");
                    return;

                }

            }
            if (secondPlayerCards.Count == 0)
            {
                for (int i = 0; i < firstPlayerCards.Count; i++)
                {
                    sumPoints += firstPlayerCards[i];
                }
                Console.WriteLine($"First player wins! Sum: {sumPoints}");
            }
            else if (firstPlayerCards.Count == 0)
            {
                for (int i = 0; i < secondPlayerCards.Count; i++)
                {
                    sumPoints += secondPlayerCards[i];
                }
                Console.WriteLine($"Second player wins! Sum: {sumPoints}");
            }
        }
    }


}