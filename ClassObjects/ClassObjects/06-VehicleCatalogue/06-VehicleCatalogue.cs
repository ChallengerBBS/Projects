using System;
using System.Linq;
using System.Collections.Generic;

namespace _06_VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            var vehicleList = new List<Catalogue>();
            while (command!="End")
            {
                
                var vehicleSpecs = command.Split().ToList();
                string type = vehicleSpecs[0];
                string model = vehicleSpecs[1];
                string color = vehicleSpecs[2];
                int hp = int.Parse(vehicleSpecs[3]);
                var currentVehicle = new Catalogue(type, model, color, hp);
                vehicleList.Add(currentVehicle);

                command = Console.ReadLine();
            }
            string call = Console.ReadLine();
            while (call!= "Close the Catalogue")
            {

            }
        }
    }
    class Catalogue
    {
        public Catalogue(string type, string model, string colour, int hp)
        {

            Type = type;
            Model = model;
            Colour = colour;
            Horsepower = hp;
          
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public int Horsepower { get; set; }
        public override string ToString()
        {
            return $"Type: {Type}\n" +
                $"Model: {Model}\n" +
                $"Color: {Colour}\n" +
                $"Horsepower: {Horsepower}";
        }


        
    }
}
