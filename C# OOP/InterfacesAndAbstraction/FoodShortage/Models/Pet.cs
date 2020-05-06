﻿using System;
using System.Collections.Generic;
using System.Text;
using FoodShortage.Interfaces;

namespace FoodShortage.Models
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }

        public DateTime Birthdate { get; private set; }

        public string Name { get; private set; }
    }
}
