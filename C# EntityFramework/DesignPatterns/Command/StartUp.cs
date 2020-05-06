using System;

namespace Command
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var modifyPrice = new ModifyPrice();
            var product = new Product("Phone", 500);

            Execute( modifyPrice, new ProductCommand(product, PriceAction.Increase, 22));
            Execute( modifyPrice, new ProductCommand(product, PriceAction.Increase, 150));
            Execute( modifyPrice, new ProductCommand(product, PriceAction.Decrease, 200));

            Console.WriteLine(product);

        }
        private static void Execute ( ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
