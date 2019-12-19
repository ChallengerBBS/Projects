using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    public class Sandwich : SandwichPrototype
    {
        private string _bread;
        private string _meat;
        private string _cheese;
        private string _veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            _bread = bread;
            _meat = meat;
            _cheese = cheese;
            _veggies = veggies;
        }
        public override SandwichPrototype Clone()
        {
            string ingredients = GetIngredientsList();
            Console.WriteLine($"Cloning sandwich with ingredients {ingredients}");

            return MemberwiseClone() as SandwichPrototype;
        }
        private string GetIngredientsList()
        {
            return $"{_bread}, {_meat}, {_cheese}, {_veggies}";
        }
    }
}
