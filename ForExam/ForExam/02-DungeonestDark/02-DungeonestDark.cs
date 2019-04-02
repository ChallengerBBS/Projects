using System;
using System.Linq;
using System.Collections.Generic;

namespace _02_DungeonestDark
{
    class Program
    {
        static void Main(string[] args)
        {
            var room = Console.ReadLine().Split("|").ToList();
            var health = 100;
            var coins = 0;
            var bestRoom = 1;

            for (int i = 0; i < room.Count; i++)
            {
                var action = room[i].Split();

                if (action[0] == "potion")
                {
                    int heal = int.Parse(action[1]);
                    health += heal;
                    if (health > 100)
                    {
                        health -= heal;
                        Console.WriteLine($"You healed for {100 - health} hp.");
                        health = 100;
                    }
                    else
                        Console.WriteLine($"You healed for {heal} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (action[0] == "chest")
                {
                    int foundCoins = int.Parse(action[1]);
                    coins += foundCoins;
                    Console.WriteLine($"You found {foundCoins} coins.");

                }
                else
                {
                    string monster = action[0];
                    int damage = int.Parse(action[1]);

                    health -= damage;
                    if (health<=0)
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {bestRoom}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }
                }

                    bestRoom++;
            }
            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Health: {health}"); 
        }
    }
}
