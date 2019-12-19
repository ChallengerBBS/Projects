using System;

namespace Facade
{
   public  class StartUp
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                         .Info
                            .WithType("Mercedes")
                            .WithColor("Black")
                            .WithNumberOfDoors(2)
                        .Built
                            .InCity("Stuttgart")
                             .AtAddress("Nazi 6")
                        .Build();

            Console.WriteLine(car);
        }
    }
}
