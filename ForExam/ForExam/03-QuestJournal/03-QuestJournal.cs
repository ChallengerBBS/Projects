using System;
using System.Linq;
using System.Collections.Generic;

namespace _03_QuestJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            var beginnerQuests = Console.ReadLine().Split(", ").ToList();
            string command = Console.ReadLine();
            while (command!="Retire!")
            {
                var commandLine = command.Split(" - ").ToList();
                var action = commandLine[0];
                var quest = commandLine[1];
                if (action == "Start")
                {
                    if (!beginnerQuests.Contains(quest))
                    {
                        beginnerQuests.Add(quest);
                    }
                }
                else if (action == "Complete")
                {
                    if (beginnerQuests.Contains(quest))
                    {
                        beginnerQuests.Remove(quest);
                    }
                    
                        
                }
                else if (action == "Side Quest")
                {
                    var sideQuest = quest.Split(":").ToList();
                    string mainQuest = sideQuest[0];
                    string addedQuest = sideQuest[1];
                    if (beginnerQuests.Contains(mainQuest))
                    {
                        var insertIndexAt = beginnerQuests.IndexOf(mainQuest);
                        if (!beginnerQuests.Contains(addedQuest))
                        beginnerQuests.Insert(insertIndexAt + 1, addedQuest);
                    }

                }
                else if (action == "Renew")
                {
                    if (beginnerQuests.Contains(quest))
                    {
                        beginnerQuests.Remove(quest);
                        beginnerQuests.Add(quest);
                    }
                }

                command = Console.ReadLine();
            }
            
            Console.WriteLine(String.Join(", ",beginnerQuests));

        }
    }
}
