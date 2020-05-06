using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            var band = new List<Band>();
            while ((command = Console.ReadLine()) != "start of concert")
            {
                var commandLine = command.Split("; ").ToList();
                var eachBand = new Band();
                if (commandLine[0] == "Add")
                {

                    string bandName = commandLine[1];
                    var members = commandLine[2].Split(", ").ToList();

                    eachBand.Add(bandName, members);
                    band.Add(eachBand);
                }
                else if (commandLine[0] == "Play")
                {

                    string bandName = commandLine[1];
                    int time = int.Parse(commandLine[2]);

                    eachBand.Add(bandName, time);

                }


            }

        }
    }
    class Band
    {
        string BandName { get; set; }
        List<string> Members { get; set; }
        int Time { get; set; }

        public void Add(string bandName, List<string> members)
        {
            BandName = bandName;
            Members = members;

        }
        public void Play(string bandName, int time)
        {
            BandName = bandName;
            Time = time;
        }
    }
}
