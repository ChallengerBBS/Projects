using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const string defaultName = "Tommy Vercetti";
        private const int initLifePoints = 100;
        public MainPlayer()
            : base(defaultName, initLifePoints)
        {
        }
    }
}