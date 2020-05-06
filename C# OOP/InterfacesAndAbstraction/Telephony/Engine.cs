using System;
using System.Linq;
using Telephony.Exceptions;
using Telephony.Models;

namespace Telephony
{
    public class Engine
    {
        private Smartphone smartphone;

        public Engine()
        {
            this.smartphone = new Smartphone();
        }
        public Engine(Smartphone smartphone)
        {
            this.smartphone = smartphone;
        }
        public void Run()
        {
            string[] numbers = Console.ReadLine()
                .Split()
                .ToArray();
            string[] urls = Console.ReadLine()
                .Split()
                .ToArray();
            CallNumbers(numbers);
            Browse(urls);
        }

        private void Browse(string[] urls)
        {
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Browse(url));
                }

                catch (InvalidURLException e)
                {
                    Console.WriteLine(e.Message);

                }
            }
        }

        private void CallNumbers(string[] numbers)
        {
            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Call(number));

                }
                catch (InvalidPhoneNumberException e)
                {
                    Console.WriteLine(e.Message);

                }
            }
        }
    }

}