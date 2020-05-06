using System;
using System.Collections.Generic;
using System.Text;
using Wildfarm.Models.Foods.Entities;

namespace Wildfarm.Models.Animals.Entities
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override List<Type> PrefferedFood => new List<Type>{typeof(Vegetable), typeof(Fruit), typeof(Meat),typeof(Seeds)};
        protected override double WeightMultiplier => 0.35;
        public override string AskFood()
        {
            return "Cluck";
        }
    }
}
