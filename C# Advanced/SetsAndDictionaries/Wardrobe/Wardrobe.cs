using System;
using System.Linq;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine()
                    .Split(" -> ");
                string color = input[0];
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                string[] clothes = input[1].Split(",").ToArray();
                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(clothes[j]))
                    {
                        wardrobe[color].Add(clothes[j], 0);
                    }
                    wardrobe[color][clothes[j]]++;
                }
            }
            var targetClothInfo = Console.ReadLine().Split();
            string targetColor = targetClothInfo[0];
            string targetCloth = targetClothInfo[1];

            foreach (var (color, clothes)  in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var (cloth, counts) in clothes)
                {
                    var result = $"* {cloth} - {counts}";
                    if (color == targetColor&&cloth==targetCloth)
                    {
                        result += " (found!)";
                    }
                    Console.WriteLine(result);
                }
            }
        }
    }
}
