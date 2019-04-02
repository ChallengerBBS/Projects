using System;

namespace LAB_10_GetMaxValue
{
    class Program
    {
        static void Main(string[] args)
        {
            string convertType = Console.ReadLine();
            string firstValue = Console.ReadLine();
            string secondValue = Console.ReadLine();
            switch (convertType)
            {
                case "int":
                    {
                        int firstValue01 = int.Parse(firstValue);
                        int secondValue02 = int.Parse(secondValue);

                        Console.WriteLine(GetMaxIntType(firstValue01, secondValue02));
                        break;
                    }
                case "char":
                    {
                        char firstValue01 = char.Parse(firstValue);
                        char secondValue02 = char.Parse(secondValue);

                        Console.WriteLine(GetMaxCharType(firstValue01, secondValue02));
                        break;
                    }
                case "string":
                    {
                        Console.WriteLine(GetMaxStringType(firstValue, secondValue));
                        break;
                    }
            }
        }

        private static string GetMaxStringType(string firstValue, string secondValue)
        {
            if (firstValue.CompareTo(secondValue) >= 0)
                return firstValue;
            else
                return secondValue; 
                                    
         
        }

        private static char GetMaxCharType(char firstValue01, char secondValue02)
        {
            if (firstValue01 > secondValue02)
                return firstValue01;
            else
                return secondValue02;
        }

        private static int GetMaxIntType(int firstValue01, int secondValue02)
        {
            if (firstValue01 > secondValue02)
                return firstValue01;
            else
                return secondValue02;
        }
    }
}
