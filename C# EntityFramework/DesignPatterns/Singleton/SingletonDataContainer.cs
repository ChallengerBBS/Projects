using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Singleton
{
    public class SingletonDataContainer : ISingletonContainer
        
    {
        public static SingletonDataContainer Instance { get; } = new SingletonDataContainer();

        private Dictionary<string, int> _capitals = new Dictionary<string, int>();
        public SingletonDataContainer()
        {
            Console.WriteLine("Initializing singeton object");
             
            var elements = File.ReadAllLines(@"E:\C#\Projects\EntityFramework\DesignPatterns\DesignPatterns-Lab\Singleton\capitals.txt");
            for (int i = 0; i < elements.Length; i+=2)
            {
                _capitals.Add(elements[i], int.Parse(elements[i + 1]));

            }
        }

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }
    }
}
