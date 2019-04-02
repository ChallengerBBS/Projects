using System;

class MultiplyTable
{
    static void Main(string[] args)
    {
        // Да се вземат стойностите на еденици, десети и стотици в отделни променливи
        // Да се завъртят в цикли за умножение между създадените промнливи

        int n = int.Parse(Console.ReadLine());      // Чете трицифрено число

        int singleDigitNum = 0;         // променлива за еденици
        int doubleDigitNum = 0;         // променлива за десетици
        int tripleDigitNum = 0;         // променлива за стотици


        singleDigitNum = n % 10;
        // "%10" винаги връща последното число от делимото (еденици в едноцифрено, двуцифрено, трицифрено,..n-цифрени числа)


        doubleDigitNum = (n / 10) % 10;
        // "/10" премахва последното число (при променлива int)
        // В случая извежда десетите от трицифрено число


        tripleDigitNum = n / 100;
        // премахва еденици и десетици от трицифрено число
        //"tripleDigit = ((tempDigit / 10) / 10) % 10;" еквивалентна команда


        for (int singleD = 1; singleD <= singleDigitNum; singleD++)         // цикъл за едениците
        {
            for (int doubleD = 1; doubleD <= doubleDigitNum; doubleD++)     // цикъл за десетиците
            {
                for (int tripleD = 1; tripleD <= tripleDigitNum; tripleD++) // цикъл за стотиците
                {
                    Console.WriteLine($"{singleD} * {doubleD} * {tripleD} = {singleD * doubleD * tripleD};");
                    // печата резултата от завъртането на всеки един цикъл
                }
            }
        }
    }
}