using System;
using System.Collections.Generic;
using System.Text;
using Wildfarm.Models.Foods.Entities;

namespace Wildfarm.Models.Animals.Entities
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override List<Type> PrefferedFood => new List<Type> { typeof(Vegetable), typeof(Fruit)};
        protected override double WeightMultiplier => 0.1;
        public override string AskFood()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
