using System;

namespace P01Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = 0d;
            string input = Console.ReadLine();
            while (input != "Start")
            {

                double money = double.Parse(Console.ReadLine());

                if (money == 0.1 ||
                    money == 0.2 ||
                    money == 0.5 ||
                    money == 1 ||
                    money == 2)
                    balance += money;
                else
                    Console.WriteLine($"Cannot accept { money}");
                input = Console.ReadLine();
            }
            
            while (input != "End")
            {
                double productPrice = 0;
                    switch (input)
                    {
                        case "Nuts":
                        productPrice = 2.0;
                        break;
                            
                        case "Water":
                        productPrice = 0.7;
                        break;
                    case "Crisps":
                        productPrice = 1.5;
                        break;
                    case "Soda":
                        productPrice = 0.8;
                        break;
                    case "Coke":
                        productPrice = 1.0;
                        break;
                    
                        default: Console.WriteLine("Invalid product"); break;

                    }
                if (balance >= productPrice && productPrice > 0)
                {
                    string productToLower = input.ToLower();
                    Console.WriteLine($"Purchased {productToLower}");
                    balance -= productPrice;
                }
                else if (productPrice>0)
                    Console.WriteLine("Sorry, not enough money");
                input = Console.ReadLine();
            }
           if (input=="End")
                Console.WriteLine($"Change: {balance}");
            

        }


         
                
        }
}



