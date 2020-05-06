using System;
using System.Collections.Generic;
using System.Linq;

namespace VaporWinterSale
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString = Console.ReadLine().Split(", ");    
            var gameName = string.Empty;
            var gameDlc = string.Empty;
            var gamePrice = 0.0;
            var gamesAndPrices = new Dictionary<string, double>();
            var gamesAndDlc = new Dictionary<string, string>();

            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i].Contains(":"))
                {
                    var gameDlcSplit = inputString[i].Split(":");
                    gameName = gameDlcSplit[0];
                    gameDlc = gameDlcSplit[1];
                    if (gamesAndPrices.ContainsKey(gameName))
                    {
                        gamesAndDlc.Add(gameName, gameDlc);
                        gamesAndPrices[gameName] += (gamesAndPrices[gameName] * 0.2);
                    }
                }

                else if (inputString[i].Contains("-"))
                {
                    var gamePriceSplit = inputString[i].Split("-");
                    gameName = gamePriceSplit[0];
                    gamePrice = double.Parse(gamePriceSplit[1]);
                    gamesAndPrices.Add(gameName, gamePrice);
                }
            }

            var gamesWithDlcToPrint = new Dictionary<string, double>();
            var gamesWithoutDlcToPrint = new Dictionary<string, double>();

            foreach (var game in gamesAndPrices)
            {
                var name = game.Key;
                var price = game.Value;
                if (gamesAndDlc.ContainsKey(game.Key))
                {
                    var loweredPrice = price - (price * 0.5);
                    gamesWithDlcToPrint.Add(name, loweredPrice);
                }
                else
                {
                    var loweredPrice = price - (price * 0.2);
                    gamesWithoutDlcToPrint.Add(name, loweredPrice);
                }
            }
            foreach (var game in gamesWithDlcToPrint.OrderBy(x=>x.Value))
            {
                var name = game.Key;
                var price = game.Value;
                Console.WriteLine($"{name} - {gamesAndDlc[name]} - {price:f2}");
            }
            foreach (var game in gamesWithoutDlcToPrint.OrderByDescending(x => x.Value))
            {
                var name = game.Key;
                var price = game.Value;
                Console.WriteLine($"{name} - {price:f2}");
            }
        }
    }
}
