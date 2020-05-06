﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using Wildfarm.Models.Animals.Entities;
using Wildfarm.Models.Animals.Interfaces;
using Wildfarm.Models.Foods.Factory;
using Wildfarm.Models.Foods.Interfaces;

namespace Wildfarm.Core
{
    public class Engine
    {
        private List<Animal> animals;
        private FoodFactory foodFactory;
        public Engine()
        {
            animals = new List<Animal>();
            foodFactory=new FoodFactory();
        }

        public void Run()
        {
            string command = Console.ReadLine();
            while (command!="End")
            {
                string foodInput = Console.ReadLine();

                IAnimal animal = GetAnimal(command);
                IFood food = GetFood(foodInput);

                Console.WriteLine(animal.AskFood());

                try
                {
                    animal.Feed(food);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                    
                }

                command = Console.ReadLine();
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private IFood GetFood(string foodInput)
        {
            string[] foodArgs = foodInput
                .Split()
                .ToArray();

            string foodType = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);

            IFood food = this.foodFactory.ProduceFood(foodType, quantity);

            return food;
        }

        private Animal GetAnimal(string command)
        {
            string[] animalArgs = command.Split().ToArray();
            string type = animalArgs[0];
            string name = animalArgs[1];
            double weight = double.Parse(animalArgs[2]);

            Animal animal;

            if (type == "Owl")
            {
                double wingSize = double.Parse(animalArgs[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(animalArgs[3]);

                animal = new Hen(name, weight, wingSize);
            }
            else
            {
                string livingRegion = animalArgs[3];
                if (type == "Dog")
                {
                    animal=new Dog(name, weight, livingRegion);
                }
                else if (type == "Mouse")
                {
                    animal = new Mouse(name,weight,livingRegion);
                }
                else
                {
                    string breed = animalArgs[4];

                    if (type == "Cat")
                    {
                        animal=new Cat(name,weight,livingRegion,breed);
                    }
                    else if (type == "Tiger")
                    {
                        animal = new Tiger(name, weight,livingRegion,breed);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid animal type !");
                    }
                }
            }

            this.animals.Add(animal);
            return animal;
        }
    }
}