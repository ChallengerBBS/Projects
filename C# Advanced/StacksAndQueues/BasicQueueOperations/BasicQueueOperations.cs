using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int numberOfPushes = int.Parse(input[0]);
            int numberOfPops = int.Parse(input[1]);
            int numberToFind = int.Parse(input[2]);

            var stack = new Queue<int>();
            var numbersToPush = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int smallestNumber = int.MaxValue;

            for (int i = 0; i < numbersToPush.Length; i++)
            {
                if (numberOfPushes == 0)
                {
                    break;
                }
                stack.Enqueue(numbersToPush[i]);
                numberOfPushes--;

            }
            for (int i = 0; i < numberOfPops; i++)
            {
                stack.Dequeue();
            }
            foreach (var number in stack)
            {
                if (number < smallestNumber)
                {
                    smallestNumber = number;
                }
                if (number == numberToFind)
                {

                    Console.WriteLine("true");
                    return;
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            Console.WriteLine(smallestNumber);
        }
    }
}
