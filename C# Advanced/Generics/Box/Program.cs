using System;
using System.Linq;

namespace Box
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Box<double> myBox = new Box<double>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                myBox.Add(double.Parse(input));
            }
            double stringToCompare = double.Parse(Console.ReadLine());
            myBox.Compare(stringToCompare);

            var result = myBox.CountGreater;
            Console.WriteLine(result);
        }
    }
}
