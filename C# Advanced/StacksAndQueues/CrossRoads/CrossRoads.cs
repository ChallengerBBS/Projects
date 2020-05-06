using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossRoads
{
    class Program
    {
        static void Main(string[] args)
        {
            var carQueue = new Queue<string>();
            int greenLightsDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            var hittedChar = ' ';
            bool isHit = false;
            var hitCarName = string.Empty;
            int carsPassed = 0;

            var input = Console.ReadLine();

            while (input != "END")
            {
                if (input!="green")
                {
                    carQueue.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }

                int currentGreenLightDuration = greenLightsDuration;
                while (currentGreenLightDuration>0&& carQueue.Count > 0)
                {
                    string carName = carQueue.Dequeue();
                    int carLength = carName.Length;
                    if (carLength - currentGreenLightDuration >= 0)
                    {
                        carsPassed++;
                        currentGreenLightDuration -= carLength;
                    }
                    else
                    {
                        currentGreenLightDuration += freeWindowDuration;
                        if (currentGreenLightDuration - carLength >= 0)
                        {
                            carsPassed++;
                            break;
                        }
                        else
                        {
                            isHit = true;
                            hitCarName = carName;
                            hittedChar = carName[currentGreenLightDuration];
                            break;
                        }
                    }
                    if (isHit)
                        break;
                }
                input = Console.ReadLine();
            }
            if(isHit)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hitCarName} is hit at {hittedChar}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
            }
        }
    }
}
