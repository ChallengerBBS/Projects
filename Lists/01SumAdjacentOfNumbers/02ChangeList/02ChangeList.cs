using System;
using System.Linq;

namespace _02ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var command = Console.ReadLine().Split().ToList();
            while (command[0]!="end")
            {
                if(command[0]=="Delete")
                {
                    int elementToBeRemoved = int.Parse(command[1]);
                    numbers.RemoveAll(element=> element==elementToBeRemoved);
                }
                else if (command[0]=="Insert")
                {
                    int element = int.Parse(command[1]);
                    int position = int.Parse(command[2]);
                    numbers.Insert(position, element);
                }
                command = Console.ReadLine().Split().ToList();
            }
            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}
