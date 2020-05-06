using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dto;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());
            using (var db = new ProductShopContext())
            {
                //var inputJson = File.ReadAllText("./../../../Datasets/categories-products.json");

                var result = GetCategoriesByProductsCount(db);

                Console.WriteLine(result);
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";

        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {

            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null);
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price > 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context.Users
                    .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(u => new
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        SoldProducts = u.ProductsSold
                                        .Where(ps => ps.Buyer != null)
                                        .Select(ps => new
                                        {
                                            Name = ps.Name,
                                            Price = ps.Price,
                                            BuyerFirstName = ps.Buyer.FirstName,
                                            BuyerLastName = ps.Buyer.LastName
                                        }).ToList()
                    })
                    .ToList();

            DefaultContractResolver resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(usersWithSoldProducts, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = resolver
            });

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var exportCategories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count())
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count(),
                    AveragePrice = $@"{c.CategoryProducts
                    .Sum(p => p.Product.Price) / c.CategoryProducts.Count():F2}",
                    TotalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):F2}"
                })
                .ToList();

            DefaultContractResolver resolver = new DefaultContractResolver()
            {

                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(exportCategories, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = resolver
            });


            return json;
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            //var users = context.Users
            //               .Where(u => u.ProductsSold.Any(p=>p.Buyer!=null))  
            //               .Select(u => new
            //               {
            //                   firstName = u.FirstName,
            //                   lastName = u.LastName,
            //                   age = u.Age,
            //                   soldProducts = new
            //                   {
            //                       count = u.ProductsSold
            //                       .Where(p => p.Buyer != null)
            //                       .Count(),     
            //                       products = u.ProductsSold
            //                       .Where(p => p.Buyer != null)
            //                                    .Select(ps=> new
            //                                    {
            //                                        name = ps.Name,
            //                                        price = ps.Price
            //                                    })
            //                                    .ToList()
            //                   }
            //               })
            //               .OrderByDescending(u=>u.soldProducts.count)
            //               .ToList();

            var users = context.Users
                        .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                        .ProjectTo<UserDetailsDto>()
                        .OrderByDescending(u => u.SoldProducts.Count)
                        .ToList();

            var usersFinalOutput = new
            {
                usersCount = users.Count,
                Users = users
            };

            var resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(usersFinalOutput,
                                                  new JsonSerializerSettings()
                                                  {
                                                      ContractResolver = resolver,
                                                      Formatting = Formatting.Indented,
                                                      NullValueHandling = NullValueHandling.Ignore

                                                  });

            return json;
        }
    }
}