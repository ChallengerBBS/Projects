using System;
using System.Numerics;
namespace _11Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowBalls = int.Parse(Console.ReadLine());
            BigInteger snowballValue = 0;
            BigInteger bestSnowballValue = 0;
            int bestSnowballSnow = 0;
            int bestSnowballTime = 0;
            int bestSnowballQuality = 0;
            int snowballSnow = 0;
            int snowballTime = 0;
            int snowballQuality = 0;
            for (int i = 0; i < numberOfSnowBalls; i++)
            {
                snowballSnow = int.Parse(Console.ReadLine());
                 snowballTime = int.Parse(Console.ReadLine());
                 snowballQuality = int.Parse(Console.ReadLine());
                snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                if (snowballValue > bestSnowballValue)
                {
                    bestSnowballValue = snowballValue;
                    bestSnowballQuality = snowballQuality;
                    bestSnowballSnow = snowballSnow;
                    bestSnowballTime = snowballTime;
                }
            }
            Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {bestSnowballValue} ({bestSnowballQuality})");

        }
    }
}
