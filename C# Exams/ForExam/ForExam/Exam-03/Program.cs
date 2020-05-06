using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_03
{
    class Exam03
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split().ToList();
            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                var commandLine = command.Split().ToList();
                if (commandLine[0] == "Delete")
                {
                    int index = int.Parse(commandLine[1]);
                    if (index >= 0 && index < words.Count - 1)
                        words.RemoveAt(index + 1);
                }
                else if (commandLine[0] == "Swap")
                {
                    string firstWord = commandLine[1];
                    string secondWord = commandLine[2];
                    int indexFirstWord = words.IndexOf(firstWord);
                    int indexSecondWord = words.IndexOf(secondWord);
                    if (words.Contains(firstWord) && words.Contains(secondWord))
                    {
                        words.Remove(firstWord);
                        words.Insert(indexFirstWord, secondWord);
                        words.Remove(secondWord);
                        words.Insert(indexSecondWord, firstWord);
                    }
                }
                else if (commandLine[0] == "Put")
                {
                    string word = commandLine[1];
                    int index = int.Parse(commandLine[2]);
                    if (index > 0 && index < words.Count)
                    {

                        words.Insert(index - 1, word);
                    }


                }
                else if (commandLine[0] == "Sort")
                {
                    words = words.OrderByDescending(x => x).ToList();
                }
                else if (commandLine[0] == "Replace")
                {
                    string firstWord = commandLine[1];
                    string secondWord = commandLine[2];

                    if (words.Contains(secondWord))
                    {

                        int indexSecond = words.IndexOf(secondWord);
                        words[indexSecond] = firstWord;
                    }
                }
            }
            Console.WriteLine(String.Join(" ", words));
        }
    }
}