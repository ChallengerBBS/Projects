using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Engine
    {
        private Dictionary<string, List<string>> doctors;
        private Dictionary<string, List<List<string>>> departments;

        public Engine()
        {
            doctors = new Dictionary<string, List<string>>();
            departments = new Dictionary<string, List<List<string>>>();
        }
        public void Run()
        {
            var command = Console.ReadLine();
            while (command != "Output")
            {
                var tokens = command.Split();

                var department = tokens[0];
                var firstName = tokens[1];
                var lastName = tokens[2];
                var patient = tokens[3];

                var fullName = firstName + lastName;

                AddDoctor(fullName);
                AddDepartment(department);

                bool isEnoughSpace = departments[department]
                                         .SelectMany(x => x)
                                         .Count() < 60;
                if (isEnoughSpace)
                {
                    var room = 0;
                    doctors[fullName].Add(patient);
                    for (int currentRoom = 0; currentRoom < departments[department].Count; currentRoom++)
                    {
                        if (departments[department][currentRoom].Count < 3)
                        {
                            room = currentRoom;
                            break;
                        }
                    }
                    departments[department][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int staq))
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[args[0]][staq - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join(Environment.NewLine, doctors[args[0] + args[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }

        private void AddDepartment(string department)
        {
            if (!departments.ContainsKey(department))
            {
                departments[department] = new List<List<string>>();

                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[department].Add(new List<string>());
                }
            }
        }

        private void AddDoctor(string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
        }
    }
}
