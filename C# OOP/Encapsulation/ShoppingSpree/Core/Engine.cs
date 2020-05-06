using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingSpree.Models;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private List<Person> persons;
        private List<Product> products;
        public Engine()
        {
            this.persons = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                ReadPersonsInput();
                ReadProductsInput();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;

            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                try
                {

                    string[] commandTokens = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string personName = commandTokens[0];
                    string productName = commandTokens[1];

                    Person person = this.persons.FirstOrDefault(p => p.Name == personName);
                    Product product = this.products.FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        person.Purchase(product);

                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }

                    
                    
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);

                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, this.persons));
            

        }
        public void ReadProductsInput()
        {

            string[] productTokens = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            foreach (var pt in productTokens)
            {
                string[] productInfo = pt
                    .Split('=')
                    .ToArray();

                string name = productInfo[0];
                decimal cost = decimal.Parse(productInfo[1]);

                var product = new Product(name, cost);
                this.products.Add(product);
            }
        }

        public void ReadPersonsInput()
        {
            string[] personTokens = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            foreach (var pt in personTokens)
            {
                string[] personInfo = pt
                    .Split('=')
                    .ToArray();

                string name = personInfo[0];
                decimal money = decimal.Parse(personInfo[1]);

                var person = new Person(name, money);
                this.persons.Add(person);

            }
        }
    }
}
