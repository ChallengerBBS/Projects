﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();


            var cars = File.ReadAllText(@".\..\..\..\Datasets\cars.json");
            var customers = File.ReadAllText(@".\..\..\..\Datasets\customers.json");
            var parts = File.ReadAllText(@".\..\..\..\Datasets\parts.json");
            var sales = File.ReadAllText(@".\..\..\..\Datasets\sales.json");
            var suppliers = File.ReadAllText(@".\..\..\..\Datasets\suppliers.json");

            Console.WriteLine(GetSalesWithAppliedDiscount(context));

        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliersForDb = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliersForDb);
            context.SaveChanges();

            return $"Successfully imported {suppliersForDb.Count}.";

        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => p.SupplierId <= 31);
            context.Parts.AddRange(json);
            int count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            foreach (var carDto in json)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in carDto.PartsId)
                {
                    PartCar partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(p => p.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {json.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<Customer[]>(inputJson);
            context.Customers.AddRange(json);
            int count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<Sale[]>(inputJson);
            context.Sales.AddRange(json);
            int count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
             .OrderBy(c => c.BirthDate)
             .ThenBy(c => c.IsYoungDriver)
             .Select(c => new ExportCustomerDto
             {
                 Name = $"{c.Name}",
                 BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                 IsYoungDriver = c.IsYoungDriver
             })
             .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsToyota = context.Cars
                               .Where(c => c.Make == "Toyota")
                               .OrderBy(c => c.Model)
                               .ThenByDescending(c => c.TravelledDistance)
                               .Select(c => new ExportCarDto
                               {
                                   
                                   Make=c.Make,
                                   Model=c.Model,
                                   TravelledDistance=c.TravelledDistance
                               })
                               .ToList();
            var carsToyotaJSON = JsonConvert.SerializeObject(carsToyota, Formatting.Indented);

            return carsToyotaJSON;

        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                 .Select(c => new
                 {
                     car = new ExportCarDto
                     {
                         Make = c.Make,
                         Model = c.Model,
                         TravelledDistance = c.TravelledDistance
                     },
                     parts = c.PartCars.Select(p => new ExportPartDto
                     {
                         Name = p.Part.Name,
                         Price = $"{p.Part.Price:F2}"
                     })
                     .ToList()
                 })
                 .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;

        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count() >= 1)
                .Select(c => new ExportCustomerWithCarDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(m => m.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new ExportCarDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartCars.Sum(p => p.Part.Price):F2}",
                    priceWithDiscount = $@"{(s.Car.PartCars.Sum(p => p.Part.Price) -
                        s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100):F2}"
                })
                .Take(10)
                .ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }


    }
}