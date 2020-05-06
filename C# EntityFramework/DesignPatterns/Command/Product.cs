using System;

namespace Command
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public void IncreasePrice (int amount)
        {
            Price += amount;
            Console.WriteLine($"The price of {Name} has been increased with {amount} $.");
        }
        public void DecreasePrice(int amount)
        {
            Price -= amount;
            Console.WriteLine($"The price of {Name} has been decreased with {amount} $.");

        }

        public override string ToString()
        {
            return $"Current price of {Name} is {Price}";
        }
    }
}
