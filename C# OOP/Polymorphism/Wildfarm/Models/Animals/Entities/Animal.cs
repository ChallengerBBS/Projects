using System;
using System.Collections.Generic;
using Wildfarm.Exceptions;
using Wildfarm.Models.Animals.Interfaces;
using Wildfarm.Models.Foods.Interfaces;

namespace Wildfarm.Models.Animals.Entities
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        protected abstract List<Type> PrefferedFood { get; }

        protected abstract double WeightMultiplier { get; }

        public abstract string AskFood();

        public void Feed(IFood food)
        {
            if (!this.PrefferedFood.Contains(food.GetType()))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidFoodTypeException, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += food.Quantity * this.WeightMultiplier;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
