using System;
using System.Linq;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var usernamesSet = new HashSet<string>();
            for (int i = 0; i < count; i++)
            {
                string username = Console.ReadLine();
                if (!usernamesSet.Contains(username))
                {
                    usernamesSet.Add(username);
                }
            }
            foreach (var username in usernamesSet)
            {
                Console.WriteLine(username);
            }
        }
    }
}
