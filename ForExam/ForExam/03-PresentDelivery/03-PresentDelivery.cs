using System;
using System.Collections.Generic;
using System.Linq;
namespace _03_PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            var houseAndPresents = Console.ReadLine().Split('@').Select(int.Parse).ToList();
            string command;
            int currentPosition = 0;
            int houseAccomplished = 0;
            while ((command=Console.ReadLine())!="Merry Xmas!")
            {
                
                string[] commandLine = command.Split();
                int jumpLenght = int.Parse(commandLine[1]);
                currentPosition += jumpLenght;
                while(currentPosition>=houseAndPresents.Count)
                {
                    currentPosition -= houseAndPresents.Count;
                }
                if(houseAndPresents[currentPosition]==0)
                {
                    Console.WriteLine($"House {currentPosition} will have a Merry Christmas.");
                }
                else if (houseAndPresents[currentPosition] != 0)
                {
                    houseAndPresents[currentPosition] -= 2;
                    if (houseAndPresents[currentPosition] <= 0)
                        houseAccomplished++;
                }
               
                if (houseAccomplished == houseAndPresents.Count)
                    break;

            }
            if (houseAccomplished == houseAndPresents.Count)
            {
                Console.WriteLine($"Santa's last position was {currentPosition}.");
                Console.WriteLine("Mission was successful.");

            }
            else
            {
                Console.WriteLine($"Santa's last position was {currentPosition}.");
                Console.WriteLine($"Santa has failed {houseAndPresents.Count - houseAccomplished} houses.");
            }

        }
    }
}
