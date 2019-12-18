﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComparingPersons
{
    public class Person : IComparable<Person>
    {

        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result ==0)
            {
                result = this.Age.CompareTo(other.Age);
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            return this.Name == ((Person)obj).Name  && this.Age==((Person)obj).Age;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode() + (257*53);
        }
    }
}
