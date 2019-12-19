using AutoMapper;

using ProductShop.Data;
using ProductShop.Models;
using ProductShop.Dtos.Import;
using ProductShop.Dtos.Export;

using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => 
            { 
                cfg.AddProfile<ProductShopProfile>(); 
            });

            var dbContext = new ProductShopContext();

           

            var usersXml = File.ReadAllText(@".\..\..\..\Datasets\users.xml");
            var productsXml = File.ReadAllText(@".\..\..\..\Datasets\products.xml");
            var categoriesXml = File.ReadAllText(@".\..\..\..\Datasets\categories.xml");
            var categoriesProductsXml = File.ReadAllText(@".\..\..\..\Datasets\categories-products.xml");


            Console.WriteLine(GetCategoriesByProductsCount(dbContext));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            var usersDto = (ImportUserDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.AddRange(users);
            context.SaveChanges();


            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));
            var productsDto = (ImportProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Product> products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = Mapper.Map<Product>(productDto);
                products.Add(product);
            }

            context.Products.AddRange(products);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));
            var categoriesDto = (ImportCategoryDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                var category = Mapper.Map<Category>(categoryDto);
                categories.Add(category);
            }

            context.AddRange(categories);
            context.SaveChanges();


            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductsDto[]), new XmlRootAttribute("CategoryProducts"));

            var categoryProductsDto = ((ImportCategoryProductsDto[])xmlSerializer.Deserialize(new StringReader(inputXml)))
                                                                                 .ToList();

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoryProductsDto)
            {
                var targetProduct = context.Products.Find(categoryProductDto.ProductId);
                var targetCategory = context.Categories.Find(categoryProductDto.CategoryId);

                if (targetProduct != null && targetCategory != null)
                {
                    var category = Mapper.Map<CategoryProduct>(categoryProductDto);
                    categoryProducts.Add(category);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
              .Where(p => p.Price >= 500 && p.Price <= 1000)
              .OrderBy(p => p.Price)
              .Select(p => new ExportProductsInRangeDto
              {
                  Name = p.Name,
                  Price = p.Price,
                  Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
              })
              .Take(10)
              .ToArray();

            var xmlSerializer =
                new XmlSerializer(typeof(ExportProductsInRangeDto[]), new XmlRootAttribute("Products"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }


        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                               .Where(u => u.ProductsSold.Any())
                               .Select(x => new ExportUserSoldProductsDto
                               {
                                   FirstName = x.FirstName,
                                   LastName = x.LastName,
                                   ProductDto = x.ProductsSold.Select(p => new ProductDto
                                   {
                                       Name = p.Name,
                                       Price = p.Price
                                   })
                                   .ToArray()
                               })
                               .OrderBy(f=>f.LastName)
                               .ThenBy(f=>f.FirstName)
                               .Take(5)
                               .ToArray();

            var xmlSerializer =
               new XmlSerializer(typeof(ExportUserSoldProductsDto[]), new XmlRootAttribute("Users"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                                    .Select(c=>new ExportCategoryCountDto 
                                    { 
                                        Name= c.Name,
                                        Count= c.CategoryProducts.Count(),
                                        AveragePrice = c.CategoryProducts.Average(cp=>cp.Product.Price),
                                        TotalRevenue= c.CategoryProducts.Sum(cp=>cp.Product.Price)
                                    })
                                     .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCategoryCountDto[]), new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
           
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
               .Where(u => u.ProductsSold.Any())
               .OrderByDescending(p => p.ProductsSold.Count())
               .Select(u => new ExportUserAndProductDto
               {
                   FirstName = u.FirstName,
                   LastName = u.LastName,
                   Age = u.Age,
                   SoldProductsDto = new SoldProductsDto
                   {
                       Count = u.ProductsSold.Count(),
                       ProductDto = u.ProductsSold
                       .Select(p => new ProductDto
                       {
                           Name = p.Name,
                           Price = p.Price
                       })
                       .OrderByDescending(p => p.Price)
                       .ToArray()
                   }
               })
               .Take(10)
               .ToArray();

            var result = new ExportCustomUserProductDto
            {
                Count = context.Users.Count(p => p.ProductsSold.Any()),
                ExportUserAndProductDto = users
            };

            var xmlSerializer = new XmlSerializer(typeof(ExportCustomUserProductDto), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), result, namespaces);

            return sb.ToString().TrimEnd();
        }

  


    }
}