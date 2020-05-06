using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        protected abstract double FuelConsumIncreasement { get; }
        public string Drive(double distance)
        {
            double fuelNeededToDrive = distance * (FuelConsumIncreasement + FuelConsumption);
            if (fuelNeededToDrive <= FuelQuantity)
            {
                FuelQuantity -= fuelNeededToDrive;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            return $"{this.GetType().Name} needs refueling";
        }

        public virtual  void Refuel(double quantity)
        {
            FuelQuantity += quantity;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
