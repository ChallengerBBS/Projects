using System;

namespace _10Pokemon
{
    class pokemon
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int pokeDistance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int originalPokePower = pokePower;
            int pokedTargets = 0;
            while (pokePower>=pokeDistance)
            {
                pokePower -= pokeDistance;
                pokedTargets++;
                if (pokePower == (originalPokePower / 2)&& exhaustionFactor!=0 )
                    pokePower /= exhaustionFactor;
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(pokedTargets);
        }
    }
}
