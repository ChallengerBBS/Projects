using System;
using System.Collections.Generic;
using System.Text;
using Wildfarm.Models.Foods.Entities;

namespace Wildfarm.Models.Animals.Entities
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override List<Type> PrefferedFood => new List<Type>{typeof(Vegetable),typeof(Meat)};
        protected override double WeightMultiplier => 0.3;
        public override string AskFood()
        {
            return "Meow";
        }
    }
}
