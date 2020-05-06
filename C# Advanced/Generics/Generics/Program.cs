using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] =="END")
                {
                    break;
                }
                string name = input[0];
                int age = int.Parse(input[1]);

                people.Add(new Person(name, age));
            }
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
