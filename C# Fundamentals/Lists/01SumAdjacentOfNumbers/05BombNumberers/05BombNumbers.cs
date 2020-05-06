using System;
using System.Collections.Generic;
using System.Linq;

namespace _05BombNumberers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var detonationData = Console.ReadLine().Split().Select(int.Parse).ToList();
            int bombNumber = detonationData[0];
            int bombPower = detonationData[1];
            BombNumberExecution(numbers, bombNumber, bombPower);
            int totalSum = 0;
            foreach (var sumOfElements in numbers)
            {
                totalSum += sumOfElements;
            }
            Console.WriteLine(totalSum);

        }

        private static void BombNumberExecution(List<int> numbers, int bombNumber, int bombPower)
        {
            while (numbers.Contains(bombNumber))
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] == bombNumber)
                    {
                        int leftsideExplosionIndex = i - bombPower;
                        if (leftsideExplosionIndex < 0)
                            leftsideExplosionIndex = 0;
                        int rightsideExplosionIndex = i + bombPower;
                        if (rightsideExplosionIndex >= numbers.Count)
                            rightsideExplosionIndex = numbers.Count - 1;

                        for (int explosion = leftsideExplosionIndex; explosion <= rightsideExplosionIndex; explosion++)
                        {
                            numbers.RemoveAt(leftsideExplosionIndex);
                        }

                    }
                }
            }
        }
    }
}
