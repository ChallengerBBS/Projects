namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;
        public Vehicle(int horsepower, double fuel)
        {
            this.Horsepower = horsepower;
            this.Fuel = fuel;
        }
        public int Horsepower { get; set; }
        public double Fuel { get; set; }

        public virtual double FuelConsumption
        {
            get => DEFAULT_FUEL_CONSUMPTION;
        }

        public virtual void Drive(int kilometers)
        {
            double fuelNeeded = this.FuelConsumption * kilometers;
            if (this.Fuel>= fuelNeeded)
            {
                this.Fuel -= this.FuelConsumption * kilometers;
            }
        }

    }
}
