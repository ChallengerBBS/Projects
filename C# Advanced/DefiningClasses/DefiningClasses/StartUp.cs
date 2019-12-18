using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp

    {
        public static void Main(string[] args)
        {
            int familyMembersCount = int.Parse(Console.ReadLine());
            var family = new Dictionary<string, int>();

            for (int i = 0; i < familyMembersCount; i++)
            {
                string[] memberData = Console.ReadLine().Split().ToArray();
                string memberName = memberData[0];
                int memberAge = int.Parse(memberData[1]);

                
                family[memberName] = memberAge;

            }
            foreach (var member in family.OrderBy(p=>p.Key))
            {
                if(member.Value>30)
                {
                    Console.WriteLine($"{ member.Key} - {member.Value}");
                }
            }
            
        }
    }
}
