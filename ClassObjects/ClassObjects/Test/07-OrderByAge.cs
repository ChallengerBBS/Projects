using System;
using System.Collections.Generic;
using System.Linq;


namespace Order_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            var list = new List<Person>();

            while ((command = Console.ReadLine()) != "End")
            {
                var properties = command.Split().ToList();
                string name = properties[0];
                string id = properties[1];
                int age = int.Parse(properties[2]);
                var person = new Person(name, id, age);
                list.Add(person);


            }
            list = list.OrderBy(eachPerson => eachPerson.Age).ToList();
            Console.WriteLine(String.Join(Environment.NewLine, list));


        }
    }
    class Person
    {

        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;

        }
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }

    }
}




