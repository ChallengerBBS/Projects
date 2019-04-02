using System;
using System.Linq;

namespace _09KaminoFactory
{
    class KaminoFactory
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int longestSubSequence = -1;
            int longestSubIndex = -1;
            int longestSubSum = -1;
            int[] sequence = new int[lenght];
            string input = Console.ReadLine();
            int indexOfLonges = 0;
            int bestSequenceIndex = 1;
            while (input != "Clone them !")
            {
                int[] currentSequence = input
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int SubSequence = 0;
                int SubIndex = -1;
                int SubSum = 0;
                int count = 0;
                for (int i = 0; i < length; i++)
                {
                    if (currentSequence[i] == 1)
                    {
                        count++;
                        SubSum++;
                    }
                    else
                        if (count > SubSequence)
                    {
                        SubSequence = count;
                        SubIndex = i - count;
                    }
                    count = 0;

                }
                if (SubSequence>longestSubSequence)
                {
                    longestSubIndex = SubIndex;
                    sequence = currentSequence;
                    longestSubSequence = SubSequence;
                    longestSubSum = SubSum;
                    
                }
                else if (SubSequence == longestSubSequence && longestSubIndex> SubIndex)
                {
                    longestSubIndex = SubIndex;
                    sequence = currentSequence;
                    
                    longestSubSum = SubSum;
                }
                else if (SubSequence == longestSubSequence && longestSubIndex == SubIndex)
                {
                    
                    sequence = currentSequence;

                    longestSubSum = SubSum;
                }

                bestSequenceIndex++;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
            Console.WriteLine(String.Join(" ", sequence);
        }
    }
}
