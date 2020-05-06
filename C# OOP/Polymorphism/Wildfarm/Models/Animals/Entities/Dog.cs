﻿using System;
using System.Collections.Generic;
using System.Text;
using Wildfarm.Models.Foods.Entities;

namespace Wildfarm.Models.Animals.Entities
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override List<Type> PrefferedFood => new List<Type>{typeof(Meat)};
        protected override double WeightMultiplier => 0.4;
        public override string AskFood()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString()+$"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
