using System;
using System.Linq;

namespace PredicateNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split()
                
                .ToArray();

            Func<string, bool> filter = name => name.Length <= length;
            names = names.Where(filter).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
