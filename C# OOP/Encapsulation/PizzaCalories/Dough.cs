using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ArgumentException = System.ArgumentException;

namespace PizzaCalories
{
    public class Dough
    {
        private const double baseDoseCalories = 2;

        private string flourtype;
        private string bakingTechnique;
        private double weight;
        private Dictionary<string, double> validFlourTypes;
        private Dictionary<string, double> validbakingTechniques;

        public Dough(string flourtype, string bakingTechnique, double weight)
        {
            this.validFlourTypes = new Dictionary<string, double>();
            this.validbakingTechniques = new Dictionary<string, double>();
            this.SeedFlourTypes();
            this.SeedBakingTechniques();
            this.FlourType = flourtype;
            this.BakingTechniqueType = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourtype;
            private set
            {
                if (!validFlourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough");
                }

                this.flourtype = value;
            }
        }

        public string BakingTechniqueType
        {
            get => this.bakingTechnique;
            private set
            {
                if (!validbakingTechniques.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough");
                }
                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                }
                this.weight = value;
            }
            

        }

        public double CalculateCalories()
        {

            return baseDoseCalories * this.weight * this.validFlourTypes[this.flourtype.ToLower()] *
                   this.validbakingTechniques[this.bakingTechnique.ToLower()];
        }

        private void SeedFlourTypes()
        {
            this.validFlourTypes.Add("white", 1.5);
            this.validFlourTypes.Add("wholegrain", 1.0);
        }

        private void SeedBakingTechniques()
        {
            this.validbakingTechniques.Add("crispy", 0.9);
            this.validbakingTechniques.Add("chewy", 1.1);
            this.validbakingTechniques.Add("homemade", 1.0);
        }

    }
}
