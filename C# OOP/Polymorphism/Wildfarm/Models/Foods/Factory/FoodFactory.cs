﻿using System;
using System.Collections.Generic;
using System.Text;
using Wildfarm.Models.Foods.Entities;
using Wildfarm.Models.Foods.Interfaces;

namespace Wildfarm.Models.Foods.Factory
{
    public class FoodFactory
    {
        public IFood ProduceFood(string type, int quantity)
        {
            IFood food;

            if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food=new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food=new Seeds(quantity);
            }
            else
            {
                throw new InvalidOperationException("Invalid food input!");
            }

            return food;
        }
    }
}