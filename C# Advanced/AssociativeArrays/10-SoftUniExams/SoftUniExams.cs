using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_SoftUniExams
{
    class SoftUniExams
    {
        static void Main(string[] args)
        {
            var results = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>();
            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] commandLine = input.Split("-");
                string name = commandLine[0];
                string language = commandLine[1];
                int points = int.Parse(commandLine[2]);

                if (language == "banned")
                {

                    results.Remove(name);

                }

                else
                {

                    if (!results.ContainsKey(name))

                    {
                        results[name] = points;
                    }
                    else if (points > results[name])
                    {
                        results[name] = points;
                    }
                    if (!submissions.ContainsKey(language))
                    {
                        submissions[language] = 0;
                    }
                    submissions[language]++;
                }
            }
            Console.WriteLine("Results:");
            foreach (var item in results.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(item.Key + " | " + item.Value);

            }
            Console.WriteLine("Submissions:");
            foreach (var item in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }
    }
}
