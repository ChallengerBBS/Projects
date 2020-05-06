using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_RawData
{
    public class Engine
    {
        private List<Car> cars;

        public Engine()
        {
                this.cars = new List<Car>();
        }
        public void Run()
        {
            
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var parameters = Console.ReadLine()
                    ?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Car car = this.CreateCar(parameters);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                PrintInfo(fragile);
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.CargoType == "flamable" && x.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();
                PrintInfo(flamable);
                
            }
        }

        private void PrintInfo(List<string>cars)
        {
            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

        private Car CreateCar(string[] parameters)
        {
            var model = parameters[0];
            var engineSpeed = int.Parse(parameters[1]);
            var enginePower = int.Parse(parameters[2]);
            var cargoWeight = int.Parse(parameters[3]);
            var cargoType = parameters[4];

            var firstTirePressure = double.Parse(parameters[5]);
            var firstTireAge = int.Parse(parameters[6]);
            var firstTire = new Tire(firstTireAge, firstTirePressure);

            var secondTirePressure = double.Parse(parameters[7]);
            var secondTireAge = int.Parse(parameters[8]);
            var secondTire = new Tire(secondTireAge, secondTirePressure);

            var thirdTirePressure = double.Parse(parameters[9]);
            var thirdTireAge = int.Parse(parameters[10]);
            var thirdTire = new Tire(thirdTireAge, thirdTirePressure);

            var fourthTirePressure = double.Parse(parameters[11]);
            var fourthTireAge = int.Parse(parameters[12]);
            var fourthTire = new Tire(fourthTireAge, fourthTirePressure);

            var car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, firstTire, secondTire, thirdTire, fourthTire);
            return car;
        }
    }
}
