using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorderControl.Interfaces;
using BorderControl.Models;

namespace BorderControl.Core
{
    public class Engine
    {
        private List<IIdentifiable> citizensAndRobots;
        public Engine()
        {
            this.citizensAndRobots= new List<IIdentifiable>();
        }

        public void Run()
        {
            string entry = Console.ReadLine();

            while (entry!="End")
            {
                string[] entryArgs = entry
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (entryArgs.Length == 3)
                {
                    string name = entryArgs[0];
                    int age = int.Parse(entryArgs[1]);
                    string id = entryArgs[2];

                    var citizen = new Citizen(name, age,id);
                    citizensAndRobots.Add(citizen);
                }
                else if (entryArgs.Length == 2)
                {
                    string model = entryArgs[0];
                    string id = entryArgs[1];
                    var robot = new Robot(model, id);
                    citizensAndRobots.Add(robot);
                }


                entry = Console.ReadLine();
            }

            string removeFakeIdBy = Console.ReadLine();

            foreach (var citizenOrRobot in citizensAndRobots)
            {
                if (citizenOrRobot.Id.EndsWith(removeFakeIdBy))
                {
                    Console.WriteLine(citizenOrRobot.Id);

                }

            }

          

        }
    }
}
