using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            int carsCount = int.Parse(System.Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carsData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = carsData[0];
                double fuelAmount = double.Parse(carsData[1]);
                double fuelConsumptionPerKm = double.Parse(carsData[2]);
                Car car = new Car(carModel, fuelAmount, fuelConsumptionPerKm);
                cars.Add(car);
            }
            while(true)
            {
                string inputLine = Console.ReadLine();


                if(inputLine=="End")
                {
                    break;
                }

                string[] data = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var carModel = data[1];
                double amountOfKm = double.Parse(data[2]);

                Car car = cars.FirstOrDefault(x => x.Model == carModel);
                car.Drive(amountOfKm);


            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
