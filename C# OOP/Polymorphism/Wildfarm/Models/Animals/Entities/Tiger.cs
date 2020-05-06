using System;
using System.Collections.Generic;

using Wildfarm.Models.Foods.Entities;

namespace Wildfarm.Models.Animals.Entities
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override List<Type> PrefferedFood => new List<Type> {typeof(Meat)};
        protected override double WeightMultiplier => 1;
        public override string AskFood()
        {
            return "ROAR!!!";
        }
    }
}
