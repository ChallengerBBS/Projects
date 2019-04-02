using System;
using System.Linq;

namespace Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfWagons = int.Parse(Console.ReadLine());
            int[] train = new int[countOfWagons];
            int totalAmountOfPassengers = 0;
            for (int i = 0; i < train.Length; i++)
            {
                int passengersOnWagon = int.Parse(Console.ReadLine());
                train[i] = passengersOnWagon;
                totalAmountOfPassengers += passengersOnWagon;
            }
            foreach (var passengersInTrain in train)
            {
                Console.Write(passengersInTrain+" ");
            }
            Console.WriteLine();
            Console.WriteLine(totalAmountOfPassengers);

        }
    }
}
