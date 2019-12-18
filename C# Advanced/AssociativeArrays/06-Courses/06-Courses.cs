using System;
using System.Collections.Generic;
using System.Linq;


namespace _06_Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var regStudents = new Dictionary<string, List<string>>();
            while (true)
            {
                string[] command = Console.ReadLine().Split(" : ");

                
                if (command[0] != "end")
                {
                    string courseName = command[0];
                    string studentName = command[1];
                    var studentGroup = new List<string>();
                    if (!regStudents.ContainsKey(courseName))
                    {
                        studentGroup.Add(studentName);
                        regStudents.Add(courseName, studentGroup);

                    }
                    else
                    {
                        regStudents[courseName].Add(studentName);
                    }
                }


                if (command[0] == "end")

                {

                    break;
                }
            }

            

            foreach (var item in regStudents.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine(item.Key + ": "+ item.Value.Count);
                foreach (var student in item.Value.OrderBy(x=>x))
                {
                    Console.WriteLine("-- " + string.Join("", student));
                }

            }
            
        }
    }
}
