using System;

namespace Singleton
{
    class StartUp
    {
       
        static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Sofia"));
            var db2 = SingletonDataContainer.Instance;
            Console.WriteLine(db2.GetPopulation("Moscow"));


        }
    }
}
