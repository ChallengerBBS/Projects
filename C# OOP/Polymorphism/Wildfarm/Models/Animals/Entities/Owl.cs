using System;
using System.Collections.Generic;
using Wildfarm.Models.Foods.Entities;

namespace Wildfarm.Models.Animals.Entities
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override List<Type> PrefferedFood => new List<Type> {typeof(Meat)};
        protected override double WeightMultiplier => 0.25;
        public override string AskFood()
        {
            return "Hoot Hoot";
        }
    }
}
