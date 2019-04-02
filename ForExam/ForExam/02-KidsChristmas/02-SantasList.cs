using System;
using System.Collections.Generic;
using System.Linq;

namespace Santa_s_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> kidsList = Console.ReadLine().Split("&").ToList();
            string commands;

            while ((commands = Console.ReadLine()) != "Finished!")
            {
                string[] commandSplit = commands.Split();

                string kidsName;
                switch (commandSplit[0])
                {
                    case "Bad":
                        kidsName = commandSplit[1];
                        if (!kidsList.Contains(kidsName)) /*=>*/ kidsList.Insert(0, kidsName);
                       
                        break;
                    case "Good":
                        kidsName = commandSplit[1];
                        if (kidsList.Contains(kidsName)) /*=>*/  kidsList.Remove(kidsName);
                        break;
                    case "Rename":
                        string oldKidName = commandSplit[1];
                        kidsName = commandSplit[2];
                        if (kidsList.Contains(oldKidName))
                        {
                            int kidIndex = kidsList.IndexOf(oldKidName);
                            kidsList.RemoveAt(kidIndex);
                            kidsList.Insert(kidIndex, kidsName);
                        }
                        break;
                    case "Rearrange":
                        kidsName = commandSplit[1];
                        if (kidsList.Contains(kidsName))
                        {
                            kidsList.Remove(kidsName);
                            kidsList.Add(kidsName);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", kidsList));
        }
    }
}