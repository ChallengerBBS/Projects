using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            string firstWord = input[0];
            string secondWord = input[1];
            string longerWord = string.Empty;
            string shorterWord = string.Empty;
            int totalSum = 0;
            if (firstWord.Length>secondWord.Length)
            {
                longerWord = firstWord;
                shorterWord = secondWord;
            }
            else
            {
                longerWord = secondWord;
                shorterWord = firstWord;
            }

            for (int i = 0; i < shorterWord.Length; i++)
            {
                totalSum += (longerWord[i] * shorterWord[i]);
            }
            for (int i = shorterWord.Length; i < longerWord.Length; i++)
            {
                totalSum += longerWord[i];
            }
            Console.WriteLine(totalSum);
        }
    }
}
