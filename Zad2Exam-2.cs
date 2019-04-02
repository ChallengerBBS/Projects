using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int foodQty = int.Parse(Console.ReadLine());
            double firstDog = double.Parse(Console.ReadLine());
            double secondDog = double.Parse(Console.ReadLine());
            double thirdDog = double.Parse(Console.ReadLine());
            double firstDogFood = firstDog * days;
            double secondDogFood = secondDog * days;
            double thirdDogFood = thirdDog * days;
            double totalFood = firstDogFood + secondDogFood + thirdDogFood;
            if (totalFood<=foodQty)
                Console.WriteLine($"{Math.Floor(foodQty-totalFood)} kilos of food left.");
            else
                Console.WriteLine($"{Math.Ceiling(totalFood-foodQty)} more kilos of food are needed.");

        }
    }
}
