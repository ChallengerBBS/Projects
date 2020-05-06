using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Car
{

    public class SportCar : Car
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 10;
        public SportCar(int horsepower, double fuel) : base(horsepower, fuel)
        {
        }

        public override double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;
    }
}
