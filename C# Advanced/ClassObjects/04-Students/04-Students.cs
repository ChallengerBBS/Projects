using System;
using System.Linq;
using System.Collections.Generic;

namespace _04_Students
{
    class Student
    {
        public Student (string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            var group = new List<Student>();
            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] student = Console.ReadLine().Split();
                string firstName = student[0];
                string lastName = student[1];
                double grade = double.Parse(student[2]);
                var eachStudent = new Student(firstName, lastName, grade);
                group.Add(eachStudent);

            }
            group = group.OrderByDescending(x => x.Grade).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, group));

        }
    }
}
