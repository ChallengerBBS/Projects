using System;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine()
                .Split();
            string[] personBeerInfo = Console.ReadLine()
                .Split();
            string[] numbersInfo = Console.ReadLine()
                .Split();
            string personName = personInfo[0] + " "+ personInfo[1];
            string personAddress = personInfo[2];
            string personTown = personInfo[3];
            string personBeerName = personBeerInfo[0];
            int personBeerLitres = int.Parse(personBeerInfo[1]);
            string willDrink = personBeerInfo[2];
            bool drunkOrNot = false;
            if (willDrink=="drunk")
            {
                drunkOrNot = true;
            }
            string myName = numbersInfo[0];
            double myDouble = double.Parse(numbersInfo[1]);
            string bankName = numbersInfo[2];

            var personTuple = new Tuple<string, string, string>(personName, personAddress, personTown);
            var personBeerTuple = new Tuple<string, int, bool>(personBeerName, personBeerLitres, drunkOrNot);
            var numbersTuple = new Tuple<string, double, string>(myName, myDouble, bankName);

            Console.WriteLine(personTuple.GetInfo());
            Console.WriteLine(personBeerTuple.GetInfo());
            Console.WriteLine(numbersTuple.GetInfo());
        }
    }
}
