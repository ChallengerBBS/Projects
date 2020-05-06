using System;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaArgs = Console.ReadLine().Split();
                string pizzaName = pizzaArgs[1];

                string[] doughArgs = Console.ReadLine().Split(); 
                string doughFlourType = doughArgs[1];
                string doughBakingTech = doughArgs[2];
                double doughWeight = double.Parse(doughArgs[3]);

                Dough dough = new Dough(doughFlourType, doughBakingTech, doughWeight);
                
                var pizza = new Pizza(pizzaName, dough);

                string inputLine = Console.ReadLine();
                while (inputLine!="END")
                {
                    string[] toppingArgs = inputLine.Split();
                    string toppingType = toppingArgs[1];
                    double toppingWeight = double.Parse(toppingArgs[2]);

                    var topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                    inputLine = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories():F2} Calories.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
           
        }
    }
}
